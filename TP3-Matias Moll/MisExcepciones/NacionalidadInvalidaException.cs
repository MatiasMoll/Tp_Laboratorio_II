﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException(string message)
            :base(message)
        { }

        public NacionalidadInvalidaException()
            :this("La nacionalidad no se condice con el numero de DNI")
        { }
    }
}
