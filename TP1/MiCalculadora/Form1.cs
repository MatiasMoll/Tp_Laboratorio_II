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

namespace MiCalculadora
{

    public partial class MiCalculadora : Form
    {
        private bool bandera = false;
        private bool banderaBinario = false;
        public MiCalculadora()
        {
            InitializeComponent();
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            Numero primerOperando = new Numero(txtNumero1.Text);
            Numero segundoOperando = new Numero(txtNumero2.Text);
            string operador = cmbOperator.Text;
            lblResultado.Text = Calculadora.Operar(primerOperando, segundoOperando, operador).ToString();
            bandera = true;

        }
        private void Limpiar_Click(object sender, EventArgs e)
        {
            Limpia();
            bandera = false;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private  void Limpia()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperator.Text = "+";
            lblResultado.Text = "";
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            string aux = Numero.DecimalABinario(lblResultado.Text);
            if (bandera)
            {
                lblResultado.Text = aux;
                banderaBinario = true;
                bandera = false;
            }
            else
            {
                lblResultado.Text = "Aun no se ha operado";
            }
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (banderaBinario)
            {
                lblResultado.Text = Numero.BinarioADecimal(lblResultado.Text);
                bandera = true;
            }
            else
            {
                lblResultado.Text = "Aun no se ha operado";
            }
        }
    }

}
