using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using Excepciones;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerado
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion

        #region Atributos
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructor/Metodos
        public Alumno()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma,EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        protected override string ParticipaEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("TOMA CLASE DE {0}", claseQueToma);
            return retorno.ToString();        
        }
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendFormat("ESTADO DE CUENTA: {0}\r\n", this.estadoCuenta);
            retorno.AppendLine(ParticipaEnClase());
            
            return retorno.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public static bool operator !=(Alumno a, EClases clase)
        {
            bool retorno = true;
            if(!(a is null))
            {
                if(a.claseQueToma != clase)
                {
                    retorno = false;
                }
            }
            return retorno;
        }
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool retorno = false;
            if(!(a!=clase) && !(a.estadoCuenta == EEstadoCuenta.Deudor))
            {
                retorno = true;
            }
            return retorno;
        }
        #endregion
    }
}
