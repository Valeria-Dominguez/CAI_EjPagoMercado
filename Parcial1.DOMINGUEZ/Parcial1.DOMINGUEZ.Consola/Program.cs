using Parcial1.DOMINGUEZ.Libreria.Entidades;
using Parcial1.DOMINGUEZ.Libreria.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Consola
{
    public class Program
    {
        private static PlataformaPago _plataforma;

        static Program()
        {
            _plataforma = new PlataformaPago("PagoMercado");
        }
        static void Main(string[] args)
        {
            Reclutadora reclutadoraActiva = _plataforma.GetReclutadoraLogueada();

            string opcionMenu = "";
            do
            {
                DesplegarOpcionesMenu();
                opcionMenu = ValidacionesConsola.ValidarStrNoVac("Ingrese una opción"); // pedir el valor
                switch (opcionMenu)
                {
                    case "1":
                        ListarAdhesiones();
                        break;
                    case "2":
                        try
                        {
                            ConsultarAdhesion();
                        }
                        catch (EmpresaNoExistenteException empresaNoExistExcep)
                        {
                            Console.WriteLine(empresaNoExistExcep.Message);
                        }
                        break;
                    case "3":
                        try
                        {
                            AltaAdhesion(reclutadoraActiva);
                        }
                        catch (EmpresaNoExistenteException empresaNoExistExcep)
                        {
                            Console.WriteLine(empresaNoExistExcep.Message);
                        }
                        catch (AdhesionExistenteException adhesionExistExcep)
                        {
                            Console.WriteLine(adhesionExistExcep.Message);
                        }
                        catch (AdhesionNoPermitidaException adhesionNoPermitidaExcep)
                        {
                            Console.WriteLine(adhesionNoPermitidaExcep.Message);
                        }
                        catch (Exception exe)
                        {
                            Console.WriteLine(exe.Message);
                        }
                        break;
                    case "4":
                        try
                        {
                            EliminarAdhesion();
                        }
                        catch (EmpresaNoExistenteException empresaNoExistExcep)
                        {
                            Console.WriteLine(empresaNoExistExcep.Message);
                        }
                        catch (AdhesionNoExistenteException adhesionNoExistExcep)
                        {
                            Console.WriteLine(adhesionNoExistExcep.Message);
                        }
                        break;
                    case "X":
                        // SALIR
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
            while (opcionMenu != "X");
        }

        static void DesplegarOpcionesMenu()
        {
            Console.WriteLine("1) Listar Adhesiones");
            Console.WriteLine("2) Consultar Adhesion");
            Console.WriteLine("3) Alta Adhesion");
            Console.WriteLine("4) Eliminar Adhesion");
            Console.WriteLine("X: Terminar");
        }

        static void ListarAdhesiones()
        {
            // mostrar adhesiones
            List<Adhesion> adhesiones = _plataforma.GetListaAdhesiones();
            if (adhesiones.Count == 0)
                Console.WriteLine("No hay comercios adheridos");
            else
                foreach (Adhesion adhesion in adhesiones)
                    Console.WriteLine(adhesion.ToString());
        }

        static void ConsultarAdhesion()
        {
            // ingreso cuit
            string cuit = ValidacionesConsola.ValidarStrNoVac("Ingrese CUIT");
            // consultar adhesion
            bool adherido = _plataforma.ConsultarAdhesion(cuit);
            if (adherido)
                Console.WriteLine("Comercio adherido");
            else
                Console.WriteLine("El comercio no está adherido");
        }

        static void AltaAdhesion(Reclutadora p)
        {
            if (p == null)
                throw new Exception("No hay reclutadoras");

            // Listar comercios
            List<Comercio> comercios = _plataforma.Comercios;

            if (comercios.Count == 0)
                Console.WriteLine("No hay comercios ingresados");
            else
            {
                // usuario selecciona el cuit que desea agregar
                string cuit = ValidacionesConsola.ValidarStrNoVac("Ingrese CUIT");

                //En el método ConsultarAdhesion() además se valida si la empresa existe
                if (_plataforma.ConsultarAdhesion(cuit))
                    throw new AdhesionExistenteException("El comercio ya se encuentra adherido");

                foreach (Comercio comercio in comercios)
                {
                    if (comercio.Cuit == cuit)
                    {
                        if (comercio is ComercioOnline)
                            throw new AdhesionNoPermitidaException("No puede adherirse un comercio online");

                        // Agregar adhesión
                        Adhesion adhesion = new Adhesion(p, comercio, 0);
                        _plataforma.AgregarAdhesion(adhesion);
                        Console.WriteLine("Adhesión exitosa");
                    }
                }
            }
        }

        static void EliminarAdhesion()
        {
            // Listar comercios
            List<Comercio> comercios = _plataforma.Comercios;
            if (comercios.Count == 0)
                Console.WriteLine("No hay comercios ingresados");
            else
            {
                // usuario selecciona el cuit que desea eliminar
                string cuit = ValidacionesConsola.ValidarStrNoVac("Ingrese CUIT");
                // Eliminar adhesión
                _plataforma.EliminarAdhesion(cuit);
                Console.WriteLine("Eliminación exitosa");
            }
        }

    }
}
