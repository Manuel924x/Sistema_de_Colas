using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Colas
{
    public partial class frmMG1 : Form
    {
        public frmMG1()
        {
            InitializeComponent();
        }

        private void frmMG1_Load(object sender, EventArgs e)
        {
            btnCalcularUtilizacion.Enabled = false;
            btnCalcularMediaLlegadas.Enabled = false;
            btnCalcularMediaServicio.Enabled = false;
            btnCalcularEspera.Enabled = false;
            btnCalcularEsperaSistema.Enabled = false;
            btnCalcularEsperaClientesSistema.Enabled = false;
            btnCalcularEsperaClientesCola.Enabled = false;
            btnSistemaVacio.Enabled = false;
            btnPW.Enabled = false;
            button2.Enabled = false;
            lblLlegadas.Visible = false;
            lblServicio.Visible = false;
            lblEspera.Visible = false;
            lblUtilizacionSistema.Visible = false;
            lblEsperaSistema.Visible = false;
            lblEsperaClientesSistema.Visible = false;
            lblEsperaClientesCola.Visible = false;
            lblSistemaVacio.Visible = false;
            lblPW.Visible = false;
        }

        private void validarCampo()
        {
            var vr = !string.IsNullOrEmpty(txtEspera.Text) && !string.IsNullOrEmpty(txtLlegadas.Text)
                && !string.IsNullOrEmpty(txtServicios.Text) && !string.IsNullOrEmpty(txtSigma.Text);

            btnCalcularUtilizacion.Enabled = vr;
            btnCalcularMediaLlegadas.Enabled = vr;
            btnCalcularMediaServicio.Enabled = vr;
            btnCalcularEspera.Enabled = vr;
            btnCalcularEsperaSistema.Enabled = vr;
            btnCalcularEsperaClientesSistema.Enabled = vr;
            btnCalcularEsperaClientesCola.Enabled = vr;
            btnSistemaVacio.Enabled = vr;
            btnPW.Enabled = vr;
            button2.Enabled = vr;
        }

        private void btnCalcularUtilizacion_Click(object sender, EventArgs e)
        {
            lblUtilizacionSistema.Visible = true;

            double llegadas = Convert.ToDouble(txtLlegadas.Text); //lambda
            double servicio = Convert.ToDouble(txtServicios.Text); //miu
            double resultUtilizacionSistema = (llegadas / servicio) * 100; //p

            lblUtilizacionSistema.Text = resultUtilizacionSistema.ToString() + " %";
        }

        private void btnCalcularMediaLlegadas_Click(object sender, EventArgs e)
        {
            lblLlegadas.Visible = true;

            double llegadas = Convert.ToDouble(txtLlegadas.Text);
            double resultLlegadas = llegadas / 60; //Lambda

            lblLlegadas.Text = resultLlegadas.ToString() + " clientes por minuto.";
        }

        private void btnCalcularMediaServicio_Click(object sender, EventArgs e)
        {
            lblServicio.Visible = true;

            double servicio = Convert.ToDouble(txtServicios.Text);
            double resultServicio = servicio / 60; //m

            lblServicio.Text = resultServicio.ToString() + " clientes por minuto.";
        }

        private void btnCalcularEsperaClientesCola_Click(object sender, EventArgs e)
        {
            lblEsperaClientesCola.Visible = true;

            double llegadas = Convert.ToDouble(txtLlegadas.Text);
            double resultLlegadas = llegadas / 60; //Lambda
            double servicio = Convert.ToDouble(txtServicios.Text);
            double resultServicio = servicio / 60; //m
            double resultUtilizacionSistema = (llegadas / servicio); //utilización sin porcentaje (p)
            
            double sigma = Convert.ToDouble(txtSigma.Text);

            double resultEsperaClientesCola = (((resultLlegadas * resultLlegadas) * (sigma * sigma) +
                (resultUtilizacionSistema * resultUtilizacionSistema)) / (2 * (1 - resultUtilizacionSistema))); //Lq

            lblEsperaClientesCola.Text = resultEsperaClientesCola.ToString() + " promedio de clientes.";
        }

        private void btnCalcularEsperaClientesSistema_Click(object sender, EventArgs e)
        {
            lblEsperaClientesSistema.Visible = true;

            double llegadas = Convert.ToDouble(txtLlegadas.Text);
            double resultLlegadas = llegadas / 60; //Lambda
            double servicio = Convert.ToDouble(txtServicios.Text);
            double resultServicio = servicio / 60; //m
            double resultUtilizacionSistema = (llegadas / servicio); //utilización sin porcentaje (P)

            double sigma = Convert.ToDouble(txtSigma.Text);

            double resultEsperaClientesCola = (((resultLlegadas * resultLlegadas) * (sigma * sigma) +
                (resultUtilizacionSistema * resultUtilizacionSistema)) / (2 * (1 - resultUtilizacionSistema))); //Lq

            double resultEsperaClientesSistema = Math.Abs((resultEsperaClientesCola + resultUtilizacionSistema)); //Ls

            lblEsperaClientesSistema.Text = resultEsperaClientesSistema.ToString() + " clientes.";
        }

        private void btnCalcularEspera_Click(object sender, EventArgs e)
        {
            lblEspera.Visible = true;

            double llegadas = Convert.ToDouble(txtLlegadas.Text);
            double resultLlegadas = llegadas / 60; //Lambda

            double servicio = Convert.ToDouble(txtServicios.Text);
            double resultServicio = servicio / 60; //m
            double resultUtilizacionSistema = (llegadas / servicio); //utilización sin porcentaje (P)

            double sigma = Convert.ToDouble(txtSigma.Text);

            double resultEsperaClientesCola = (((resultLlegadas * resultLlegadas) * (sigma * sigma) +
                (resultUtilizacionSistema * resultUtilizacionSistema)) / (2 * (1 - resultUtilizacionSistema))); //Lq

            double resultEspera = resultEsperaClientesCola / resultLlegadas; //Wq

            lblEspera.Text = resultEspera.ToString() + " minuto (s).";
        }

        private void btnCalcularEsperaSistema_Click(object sender, EventArgs e)
        {
            lblEsperaSistema.Visible = true;

            double llegadas = Convert.ToDouble(txtLlegadas.Text);
            double resultLlegadas = llegadas / 60; //Lambda

            double servicio = Convert.ToDouble(txtServicios.Text);
            double resultServicio = servicio / 60; //m
            double resultUtilizacionSistema = (llegadas / servicio); //utilización sin porcentaje (P)

            double sigma = Convert.ToDouble(txtSigma.Text);

            double resultEsperaClientesCola = (((resultLlegadas * resultLlegadas) * (sigma * sigma) +
                (resultUtilizacionSistema * resultUtilizacionSistema)) / (2 * (1 - resultUtilizacionSistema))); //Lq

            double resultEspera = resultEsperaClientesCola / resultLlegadas; //Wq

            double resultEsperaSistema = resultEspera + (1 / resultServicio); //Ws

            lblEsperaSistema.Text = resultEsperaSistema.ToString() + " minuto (s).";
        }

        private void btnSistemaVacio_Click(object sender, EventArgs e)
        {
            lblSistemaVacio.Visible = true;

            double llegadas = Convert.ToDouble(txtLlegadas.Text); //lambda
            double servicio = Convert.ToDouble(txtServicios.Text); //miu
            double resultUtilizacionSistema = (llegadas / servicio) * 100; //p

            double resultSistemaVacio = Math.Abs(1-resultUtilizacionSistema); //P0

            lblSistemaVacio.Text = resultSistemaVacio.ToString() + " %";
        }

        private void btnPW_Click(object sender, EventArgs e)
        {
            lblPW.Visible = true;

            double llegadas = Convert.ToDouble(txtLlegadas.Text); //lambda
            double servicio = Convert.ToDouble(txtServicios.Text); //miu
            double resultUtilizacionSistema = (llegadas / servicio) * 100; //p

            lblPW.Text = resultUtilizacionSistema.ToString() + " %";
        }

        private void txtLlegadas_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtServicios_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtEspera_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtSigma_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnCalcularUtilizacion.Enabled = false;
            btnCalcularMediaLlegadas.Enabled = false;
            btnCalcularMediaServicio.Enabled = false;
            btnCalcularEspera.Enabled = false;
            btnCalcularEsperaSistema.Enabled = false;
            btnCalcularEsperaClientesSistema.Enabled = false;
            btnCalcularEsperaClientesCola.Enabled = false;
            btnSistemaVacio.Enabled = false;
            btnPW.Enabled = false;
            button2.Enabled = false;
            lblUtilizacionSistema.Visible = false;
            lblLlegadas.Visible = false;
            lblServicio.Visible = false;
            lblEspera.Visible = false;
            lblEsperaSistema.Visible = false;
            lblEsperaClientesSistema.Visible = false;
            lblEsperaClientesCola.Visible = false;
            lblSistemaVacio.Visible = false;
            lblPW.Visible = false;
            txtLlegadas.Text = "";
            txtServicios.Text = "";
            txtEspera.Text = "";
            txtSigma.Text = "";
        }

        private void txtLlegadas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // Solo se aceptara un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtServicios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // Solo se aceptara un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtEspera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // Solo se aceptara un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSigma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // Solo se aceptara un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMPrincipal nuevaVentana = new frmMPrincipal();
            nuevaVentana.Show();
            this.Hide();
        }
    }
}
