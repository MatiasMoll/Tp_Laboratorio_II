using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if(!(operador is null))
            {
                switch(operador)
                {
                    case "-":
                        retorno = "-";
                        break;
                    case "+":
                        retorno = "+";
                        break;
                    case "/":
                        retorno = "/";
                        break;
                    case "*":
                        retorno = "*";
                        break;

                }
            }
            return retorno;
        }
        public static double Operar(Numero n1, Numero n2, string operador)
        {
            double retorno = 0;
            string aux;
            if(!(n1 is null) && !(n2 is null) && !(operador is null))
            {
                aux = ValidarOperador(operador);
                switch(aux)
                {
                    case "-":
                        retorno = n1 - n2;
                        break;
                    case "+":
                        retorno = n1 + n2;
                        break;
                    case "/":
                        retorno = n1 / n2;
                        break;
                    case "*":
                        retorno = n1 * n2;
                        break;
                }
            }
            return retorno;
        }
    }
}
