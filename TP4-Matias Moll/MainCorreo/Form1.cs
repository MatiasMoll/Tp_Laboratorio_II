using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FormPpal : System.Windows.Forms.Form
    {
        private Correo correo = new Correo();
        public FormPpal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingId.Text);
            paquete.InformarEstado += paq_InformaEstado;
            try
            {
                this.correo += paquete;
                ActualizarEstados();
            }catch(TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message, "Tracking repetido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string info = string.Empty;
            if(elemento != null)
            {
                if(elemento is Paquete)
                {
                    info = elemento.MostrarDatos(elemento);
                }else
                {
                    info = this.correo.MostrarDatos((IMostrar<List<Paquete>>)elemento);
                }
                rtbMostar.Text = info;
                info.Guardar("salida.txt");
            }
        }
        private void ActualizarEstados()
        {
            this.lstEntregado.Items.Clear();
            this.lstEnViaje.Items.Clear();
            this.lstIngresado.Items.Clear();
            foreach (Paquete p in this.correo.Paquetes)
            {
                switch((int)p.Estado)
                {
                    case 0:
                        this.lstIngresado.Items.Add(p);
                        break;
                    case 1:
                        this.lstEnViaje.Items.Add(p);
                        break;
                    case 2:
                        this.lstEntregado.Items.Add(p);
                        try
                        {
                            PaqueteDAO.Insertar(p);
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }
        private void FormPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
        private void itemMostrar_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEntregado.SelectedItem);
        }
    }
}
