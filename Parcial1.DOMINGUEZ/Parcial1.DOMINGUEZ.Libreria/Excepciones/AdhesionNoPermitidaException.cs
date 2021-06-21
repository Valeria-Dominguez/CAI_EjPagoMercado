using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Libreria.Excepciones
{
    public class AdhesionNoPermitidaException : Exception
    {
        public AdhesionNoPermitidaException(string message) : base(message)
        {
        }
        public AdhesionNoPermitidaException() : base("Adhesión no permitida")
        {
        }
    }
}
