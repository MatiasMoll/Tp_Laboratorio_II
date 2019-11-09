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
                apellido = ValidarNombreApellido(value);
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
                nombre = ValidarNombreApellido(value);
                
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
            :this(nombre, apellido,nacionalidad)
        {
            
            StringToDNI = dni;
            
        }
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat($"NOMBRE COMPLETO: {this.apellido}, {this.nombre} \r\nNACIONALIDAD: {this.nacionalidad.ToString()}\r\n\r\n");
            return retorno.ToString();
        }

        private string ValidarNombreApellido(string dato)
        {
            string retorno = dato;
            string charInvalidName = "0123456789|°¬!#$%&/()=?¡'¿´+{}-.,;:_[]¨*";
            foreach(char car in charInvalidName)
            {
                if(dato.Contains(car))
                {
                    retorno = "";
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
                throw new NacionalidadInvalidaException();
            }
            return retorno;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux;
            int retorno = -1;
            if(!(dato is null))
            {
                if(int.TryParse(dato, out aux) && dato.Length <= 8 && !(dato is null))
                {
                    retorno =  ValidarDni(nacionalidad, aux);
                }else
                {
                    throw new DniInvalidoException();
                }
            }
            return retorno;
        }


        #endregion
    }
}
