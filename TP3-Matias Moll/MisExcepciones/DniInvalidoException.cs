using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "DNI Invalido";
        public DniInvalidoException()
            : this(mensajeBase, null)
        { }

        public DniInvalidoException(string mensaje, Exception e)
            : base(mensaje, e)
        { }

        public DniInvalidoException(Exception e)
            : this(mensajeBase, e)
        { }

        public DniInvalidoException(string mensaje)
            : this(mensaje, null)
        { }
    }
}
