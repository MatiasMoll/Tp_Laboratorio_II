using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructor/Metodos
        public Universitario()
        {

        }

        public Universitario(int legajo,string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        protected abstract string ParticipaEnClase();
        protected virtual string  MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("{0}LEGAJO NÚMERO: {1}\r\n",base.ToString(), this.legajo);
            return retorno.ToString();
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.Dni == pg2.Dni))
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Universitario)
            {
                retorno = true;
            }
            return retorno;
        }


        #endregion

    }
}
