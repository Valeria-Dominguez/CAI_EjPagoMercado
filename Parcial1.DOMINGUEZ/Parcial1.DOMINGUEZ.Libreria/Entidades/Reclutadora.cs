using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Libreria.Entidades
{
    public class Reclutadora : Empresa
    {
        private int _registro;

        public Reclutadora(int registro, string razonSocial, string cuit) : base(razonSocial, cuit)
        {
            _registro = registro;
        }

        internal override string Display()
        {
            return $"{this._registro} - {this._razonSocial}";
        }
    }
}
