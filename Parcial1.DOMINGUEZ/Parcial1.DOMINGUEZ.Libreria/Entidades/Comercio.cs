using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Libreria.Entidades
{
    public abstract class Comercio: Empresa
    {
        private int _nroHabilitacion;

        public string Cuit { get => this._cuit; }

        protected Comercio(int nroHabilitacion, string razonSocial, string cuit) : base(razonSocial, cuit)
        {
            _nroHabilitacion = nroHabilitacion;
        }

        internal override string Display()
        {
            return $"{base.ToString()} - {this._nroHabilitacion}";
        }
    }
}
