using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using System.IO;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                alumnos = value;
            }
        }
        public EClases Clase
        {
            get
            {
                return clase;
            }
            set
            {
                clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return instructor;
            }
            set
            {
                instructor = value;
            }
        }
        #endregion

        #region Constructor/Metodos
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }


        public static bool operator ==(Jornada j, Alumno a)
        {
            return !(a != j.clase);

        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j is null && a is null))
            {
                if(j != a)
                {
                    j.alumnos.Add(a);
                }

            }
            return j;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat($"CLASE DE: {this.clase} POR {instructor.ToString()}");
            retorno.AppendLine("ALUMNOS: ");
            foreach(Alumno alumno in this.alumnos)
            {
                retorno.AppendLine(alumno.ToString());
              
            }
            return retorno.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto guardador = new Texto();
            bool retorno = false;
            if(!(guardador is null && jornada is null))
            {
                retorno = guardador.Guardar(AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt", jornada.ToString());
            }
            return retorno;
        }
        public string Leer()
        {
            Texto lector = new Texto();
            string retorno = "";
            if (!(lector is null))
            {
                lector.Leer(AppDomain.CurrentDomain.BaseDirectory + "\\prueba.txt", out retorno);
            }
            return retorno;
        }

        #endregion

    }
}
