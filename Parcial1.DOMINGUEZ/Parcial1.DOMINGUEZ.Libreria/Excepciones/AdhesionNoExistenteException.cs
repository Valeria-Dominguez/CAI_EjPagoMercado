using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Libreria.Excepciones
{
    public class AdhesionNoExistenteException : Exception
    {
        public AdhesionNoExistenteException(string message) : base(message)
        {
        }
        public AdhesionNoExistenteException() : base("Adhesión inexistente")
        {
        }
    }
}
