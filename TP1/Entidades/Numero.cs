using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero ;
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;
            if (!(strNumero is null))
            {
                double.TryParse(strNumero, out retorno);
            }
            return retorno;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if(n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }
        
        private static bool ValidarBinario(string binario)
        {
            bool retorno = true;
            if (!(binario is null))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    if (binario[i] != '0' && binario[i] != '1')
                    {
                        retorno = false;
                        break;
                    }
                }
            }
            else
                retorno = false;
            return retorno;
        }
        public static string BinarioADecimal(string binario)
        {
            string retorno = "Valor Invalido";
            double aux = 0;
            if(!(binario is null) && ValidarBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    if (binario[i] == '1')
                    {
                        
                        aux += Math.Pow(2, binario.Length - i - 1);
                    }
                }
                retorno = aux.ToString();
            }
            return retorno;
        }
        public static string DecimalABinario (double numero)
        {
            string retorno = "";
            int aux = (int)numero;
            if(numero >= 0)
            {
                while (aux != 1 && aux != 0)
                {
                    if (aux % 2 == 1)
                    {
                        retorno += "1" + "";
                    }
                    else
                    {
                        retorno += "0" + "";
                    }
                    aux = aux / 2;
                }
                if (aux % 2 == 1)
                {
                    retorno += "1" + "";
                }
                else
                {
                    retorno += "0" + "";
                }
                char [] arrayAux = retorno.ToCharArray();
                Array.Reverse(arrayAux);
                retorno = new string(arrayAux);
            }
            else
            {
                retorno = "Valor Invalido";
            }
            return retorno;
        }
        public static string DecimalABinario(string numero)
        {
            string retorno = "Valor Invalido";
            double aux;
            if(double.TryParse(numero,out aux))
            {
                retorno = DecimalABinario(aux);
            }
            return retorno;
        }
    }
}
