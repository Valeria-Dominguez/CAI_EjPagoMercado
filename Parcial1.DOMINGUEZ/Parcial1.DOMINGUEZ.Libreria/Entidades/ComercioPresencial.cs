using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Libreria.Entidades
{
    public class ComercioPresencial : Comercio
    {
        private string _direccion;

        public ComercioPresencial(int nroHabilitacion, string cuit, string razonSocial, string direccion) : base(nroHabilitacion, razonSocial, cuit)
        {
            _direccion = direccion;
        }

    }
}
