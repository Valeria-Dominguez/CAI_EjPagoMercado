using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Libreria.Entidades
{
    public class Adhesion
    {
        private DateTime _fechaHoraAdhesion;
        private Reclutadora _reclutadora;
        private Comercio _comercio;
        private int _nroOrden;

        public Adhesion()
        {
        }

        public Adhesion(Reclutadora reclutadora, Comercio comercio, int nroOrden)
        {
            _fechaHoraAdhesion = DateTime.Now;
            _reclutadora = reclutadora;
            _comercio = comercio;
            _nroOrden = nroOrden;
        }

        public Comercio Comercio { get => _comercio; }
        internal int NroOrden {set => _nroOrden = value; }

        public override string ToString()
        {
            return $"{this._nroOrden} {this._comercio.Display()} está adherido a PagoMercado desde {this._fechaHoraAdhesion}";
        }
    }
}
