using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Libreria.Excepciones
{
    public class AdhesionExistenteException : Exception
    {
        public AdhesionExistenteException(string message) : base(message)
        {
        }
        public AdhesionExistenteException() : base("Adhesión Existente")
        {
        }
    }
}
