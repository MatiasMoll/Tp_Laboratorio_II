using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidException : Exception
    {
        private string mensajeBase;

        public DniInvalidException()
            :base()
        { }
        
        public DniInvalidException(string  message)
         :this()
        {
            mensajeBase = message;
        }

        public DniInvalidException(string msg, Exception e)
        :base(msg,e)
        {

        }



    }
}
