using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                if(ValidarNombreApellido(value))
                {
                    apellido = value;
                }
            }
        }

        public int Dni
        {
            get
            {
                return dni;
            }
            set
            {
                dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if(ValidarNombreApellido(value))
                {
                    nombre = value;
                }
                
            }
        }

        public string StringToDNI
        {
            set
            {
                dni = ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion

        #region Constructores/Metodos

        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        :this()
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        :this(nombre,apellido,nacionalidad)
        {
            Dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, int.Parse(dni),nacionalidad)
        {
            /*
            StringToDNI = dni;
            */
        }
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat($"NOMBRE COMPLETO: {this.apellido}, {this.nombre} \r\nNACIONALIDAD: {this.nacionalidad.ToString()}\r\n\r\n");
            return retorno.ToString();
        }

        private bool ValidarNombreApellido(string dato)
        {
            bool retorno = true;
            string charInvalidName = "0123456789|°¬!#$%&/()=?¡'¿´+{}-.,;:_[]¨*";
            foreach(char car in charInvalidName)
            {
                if(dato.Contains(car))
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno;
            if(this.nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                retorno = dato;
            }else if(this.nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {
                retorno = dato;
            }else
            {
                throw new NacionalidadInvalidaException("La nacionalida no se coincide con el DNI");
            }
            return retorno;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux;
            int retorno = 0;
            if(!(dato is null))
            {
                if(int.TryParse(dato, out aux))
                {
                    retorno = ValidarDni(nacionalidad, aux);
                }
            }
            return retorno;
        }


        #endregion
    }
}
