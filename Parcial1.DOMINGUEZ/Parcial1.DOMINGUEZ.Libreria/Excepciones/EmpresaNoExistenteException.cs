using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.DOMINGUEZ.Libreria.Excepciones
{
    public class EmpresaNoExistenteException : Exception
    {
        public EmpresaNoExistenteException(string message) : base(message)
        {
        }
        public EmpresaNoExistenteException() : base("Empresa inexistente")
        {
        }
    }
}
