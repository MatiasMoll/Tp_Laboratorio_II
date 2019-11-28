using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Enumerado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return direccionEntrega;
            }
            set
            {
                direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get 
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Constructores
        public Paquete(string direccionEntrega, string tracking)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = tracking;
            this.estado = EEstado.Ingresado;
        }
        #endregion

        #region Metodos
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string retorno = default;
            string formato = "{0} para {1}";
            if(elemento is Paquete)
            {
                Paquete aux = (Paquete)elemento;
                retorno = string.Format(formato, aux.TrackingID,aux.DireccionEntrega);

            }
            return retorno;
        }
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if(!(p1 is null && p2 is null))
            {
                if(p1.TrackingID == p2.TrackingID)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendFormat("{0}",this.MostrarDatos(this));
            return retorno.ToString();
        }
      
        public void MockCicloDeVida()
        {
            int aux = (int)this.Estado;
            while(aux != 3)
            {
                Thread.Sleep(4000);
                this.Estado = (EEstado)(aux++);
                this.InformarEstado.Invoke(new object[] { 0 },new EventArgs());

            }
            
        }
        #endregion

        #region Delegado/Eventos
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;

        #endregion

    }
}
