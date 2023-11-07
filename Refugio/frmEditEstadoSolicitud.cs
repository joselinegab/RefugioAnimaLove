using CapaEntidades;
using CapaLogica.Refugio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefugioAnimaLove.Refugio
{
    public partial class frmEditEstadoSolicitud : Form
    {
        public frmEditEstadoSolicitud()
        {
            InitializeComponent();
        }
        EstadoSolicitudLN pln = new EstadoSolicitudLN();
        public bool banActualizar;

        public bool existeCodigo(string cod)
        {
            EstadoSolicitud op = pln.GetIdEstadoSolicitud(cod);
            if (op != null)
            {
                MessageBox.Show($"El código {cod} ya existe", "Código repetido");
                return false;
            }
            else
                return true;
        }

        public void CargarDatos(EstadoSolicitud op)
        {
            txtNombre.Text = op.EstadoSoli;
            txtDescrip.Text = op.Descripcion;

        }

        public EstadoSolicitud CrearObjeto()
        {
            string tip = txtNombre.Text;
            string des = txtDescrip.Text;

            return new EstadoSolicitud(tip, des);
        }

        public bool validarEntradas()
        {
            bool val = true;
            string cod = txtNombre.Text;
            if (banActualizar == false)
            {
                val = existeCodigo(cod);
            }
            if (txtNombre.Text.Trim().Length == 0)
            {
                val = false;
            }
            return val;
        }


        public void Guardar()
        {
            try
            {
                if (validarEntradas())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Ingrese correctamente los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }
        private void frmEditEstadoSolicitud_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
