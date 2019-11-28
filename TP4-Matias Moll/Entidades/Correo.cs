using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedad
        public List<Paquete> Paquetes
        {
            get
            {
                return paquetes;
            }
            set
            {
                paquetes = value;
            }
        }
        #endregion

        #region Constructores/Metodos
        public Correo()
        {
            this.Paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        public void FinEntregas()
        {
            foreach(Thread t in this.mockPaquetes)
            {
                t.Abort();
            }
        }
        public static Correo operator +(Correo c, Paquete p)
        {
            bool flag = false;
            if(!(c is null && p is null))
            {
                foreach(Paquete paq in c.Paquetes)
                {
                    if(paq == p)
                    {
                        flag = true;
                        break;
                    }
                }
                if(flag)
                {
                    throw new TrackingIdRepetidoException("El paquete esta en viaje");
                }else
                {
                    c.Paquetes.Add(p);
                    Thread aux = new Thread(p.MockCicloDeVida);
                    aux.Start();
                    c.mockPaquetes.Add(aux);
                    
                }
            }
            return c;
        }
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string format = "{0} para {1} ({2})\r\n";
            string retorno = string.Empty;
            Correo aux = (Correo)elementos;
            foreach(Paquete p in aux.Paquetes)
            {
                retorno += string.Format(format, p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return retorno;
        }
        #endregion
    }   
}
