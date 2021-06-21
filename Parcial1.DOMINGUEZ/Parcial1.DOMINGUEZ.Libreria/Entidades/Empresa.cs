using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Libreria.Entidades
{
    public abstract class Empresa
    {
        protected string _razonSocial;
        protected string _cuit;

        protected Empresa(string razonSocial, string cuit)
        {
            _razonSocial = razonSocial;
            _cuit = cuit;
        }

        public override string ToString()
        {
            return $"{this._razonSocial} ({this._cuit})";
        }
        internal abstract string Display();

    }
}
