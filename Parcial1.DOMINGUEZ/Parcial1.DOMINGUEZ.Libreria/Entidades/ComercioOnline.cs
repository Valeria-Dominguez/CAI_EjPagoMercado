using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Libreria.Entidades
{
    public class ComercioOnline : Comercio
    {
        public ComercioOnline(int nroHabilitacion, string cuit, string razonSocial) : base(nroHabilitacion, razonSocial, cuit)
        {
        }
    }
}
