using Parcial1.DOMINGUEZ.Libreria.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Libreria.Entidades
{
    public class PlataformaPago
    {
        private List<Reclutadora> _reclutadoras;
        private List<Comercio> _comercios;
        private List<Adhesion> _adhesiones;
        private string _nombrePlataforma;
        private int _numeradorOrden;

        public PlataformaPago(string nombrePlataforma)
        {
            _nombrePlataforma = nombrePlataforma;
            _numeradorOrden = 0;

            _reclutadoras = new List<Reclutadora>();
            _comercios = new List<Comercio>();
            _adhesiones = new List<Adhesion>();

            _comercios.Add(new ComercioPresencial(5001, "30-40123456-8", "Juarez SRL", "Moldes 123"));
            _comercios.Add(new ComercioPresencial(5002, "30-40854451-1", "Moda SA", "Vidal 456"));
            _comercios.Add(new ComercioPresencial(5003, "30-40853352-9", "Ronda SA", "Vidt 887"));
            _comercios.Add(new ComercioPresencial(5004, "30-20663323-7", "Andina Inc.", "Ugarte 2020"));

            _comercios.Add(new ComercioOnline(4040, "30-18512524-3", "TodoVenta.com"));
            _comercios.Add(new ComercioOnline(4041, "30-35112685-4", "AlqInmuebles.com.ar"));
            _comercios.Add(new ComercioOnline(4042, "30-28512571-2", "DeCarpinteros.com"));

            _reclutadoras.Add(new Reclutadora(101, "Agencia Ramos SRL", "30-55123456-1"));
        }

        public List<Comercio> Comercios { get => _comercios;}

        private bool ExisteEmpresa (string cuit)
        {
            bool existe = false;

            foreach (Comercio comercio in this._comercios)
                if (comercio.Cuit == cuit)
                    existe = true;

            return existe;
        }
        private int GetUltimoNroOrden()
        {
            return this._numeradorOrden;
        }

        public Reclutadora GetReclutadoraLogueada()
        {
            if (this._reclutadoras.Count == 0)
                return null;

            return this._reclutadoras.First();
        }

        public bool ConsultarAdhesion(string cuit)
        {
            if (!ExisteEmpresa(cuit))
                throw new EmpresaNoExistenteException("No existe el comercio");

            bool adherido = false;
            foreach (Adhesion adhesion in this._adhesiones)
            {
                if (adhesion.Comercio.Cuit == cuit)
                    adherido = true;
            }
            return adherido;
        }

        public List<Adhesion> GetListaAdhesiones()
        {
            return this._adhesiones;
        }

        public void AgregarAdhesion (Adhesion adhesion)
        {
            adhesion.NroOrden = GetUltimoNroOrden() + 1;
            this._adhesiones.Add(adhesion);
            this._numeradorOrden++;
        }

        public void EliminarAdhesion(string cuit)
        {
            if (!ExisteEmpresa(cuit))
                throw new EmpresaNoExistenteException("No existe el comercio");

            Adhesion adhesionAEliminar = new Adhesion();

            foreach (Adhesion adhesion in this._adhesiones)
                if (adhesion.Comercio.Cuit == cuit)
                    adhesionAEliminar = adhesion;

            if (adhesionAEliminar==null)
                throw new Exception("Adhesion no existente");

            this._adhesiones.Remove(adhesionAEliminar);
        }

    }
}
