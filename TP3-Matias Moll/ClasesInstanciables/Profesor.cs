using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using EntidadesAbstractas;
using Excepciones;
using System.Threading;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores/Metodos
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)random.Next(0, 4));
            Thread.Sleep(250);
        }
        static Profesor()
        {
            random = new Random();
        }
        public Profesor()
        {

        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            clasesDelDia = new Queue<EClases>();
            _randomClases();
            _randomClases();
            
        }


        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            
            retorno.AppendFormat($"{base.MostrarDatos()}\r\n");
            retorno.AppendLine(ParticipaEnClase());
            return retorno.ToString();
        }
        protected override string ParticipaEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("CLASES DEL DIA:\r\n");
            foreach (EClases clases in this.clasesDelDia)
            {
                retorno.AppendFormat("{0}\r\n",clases);
            }
            return retorno.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, EClases clase)
        {
            bool retorno = false;
            if(!(i is null))
            {
                retorno = i.clasesDelDia.Contains(clase);
            }
            return retorno;
        }
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        #endregion

    }
}
