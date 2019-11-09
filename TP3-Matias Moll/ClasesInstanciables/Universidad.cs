using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Enumerado
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;
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
        public List<Profesor> Instructores
        {
            get
            {
                return profesores;
            }
            set
            {
                profesores = value;
            }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return jornadas;
            }
            set
            {
                jornadas = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];
            }
            set
            {
                jornadas[i] = value;
            }
        }
        #endregion

        #region Constructor/Metodos
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornadas = new List<Jornada>();
        }
        public static Profesor operator ==(Universidad u, EClases clases)
        {
            Profesor retorno = null;
            if (!(u is null))
            {
                foreach (Profesor p in u.profesores)
                {
                    if (p == clases)
                    {
                        retorno = p;
                        break;
                    }
                }
                if (retorno is null)
                {
                    throw new SinProfesorException();
                }
            }
            return retorno;
        }
        public static Profesor operator !=(Universidad u, EClases clases)
        {
            Profesor retorno = null;
            if (!(u is null))
            {
                foreach (Profesor p in u.profesores)
                {
                    if (p != clases)
                    {
                        retorno = p;
                    }
                }
            }
            return retorno;
        }

        public static bool operator ==(Universidad u, Profesor i)
        {
            bool retorno = false;
            if (!(u is null) && !(i is null))
            {
                foreach (Profesor p in u.Instructores)
                {
                    if (p == i)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        public static bool operator !=(Universidad u, Profesor i)
        {
            return !(u == i);
        }

        public static bool operator ==(Universidad u, Alumno a)
        {
            bool retorno = false;
            if (!(u is null) && !(a is null))
            {
                foreach (Alumno alumno in u.alumnos)
                {
                    if (alumno == a)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        public static Universidad operator +(Universidad u, EClases clase)
        {
            if (!(u is null))
            {
                Profesor p = (u == clase);
                Jornada j = new Jornada(clase, p);
                foreach (Alumno a in u.Alumnos)
                {
                    if (a == clase)
                    {
                        j.Alumnos.Add(a);
                    }
                }
                u.jornadas.Add(j);
                //u.profesores.Add(p);
                
            }
            return u;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(!(u is null) && !(a is null))
            {
                if(u != a)
                {
                    u.Alumnos.Add(a);
                }else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(!(u is null) && !(i is null))
            {
                if(u != i)
                {
                    u.Instructores.Add(i);
                }
            }
            return u;
        }

        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            if(!(uni is null))
            {
                Xml<Universidad> aux = new Xml<Universidad>();
                retorno = aux.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", uni);
            }
            return retorno;
        }
        public Universidad Leer()
        {
            Universidad retorno = null;
            Xml<Universidad> lector = new Xml<Universidad>();
            lector.Leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.txt", out retorno);
            return retorno;
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("JORNADA: ");
            foreach(Jornada j in uni.jornadas)
            {
                retorno.AppendFormat($"{j.ToString()}");
                retorno.AppendFormat("<------------------------------------------------------------->\r\n\r\n");
            }
            
            return retorno.ToString();
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion
    }
}
