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
    public partial class frmEditAdoptante : Form
    {
        public frmEditAdoptante()
        {
            InitializeComponent();
            Size = new Size(448, 500);
            this.CenterToScreen();

        }
        AdoptanteLN pln = new AdoptanteLN();
        public bool banActualizar;

        public bool existeCodigo(string cod)
        {
            Adoptante op = pln.GetIdAdoptante(cod);
            if (op != null)
            {
                MessageBox.Show($"El código {cod} ya existe", "Código repetido");
                return false;
            }
            else
                return true;
        }

        public void CargarDatos(Adoptante op)
        {
            txtId.Text = op.IdAdoptante;
            txtIdent.Text = op.Identificacion;
            txtNombres.Text = op.Nombres;
            txtApellidos.Text = op.Apellidos;
            if (op.Sexo == 'M')
                rbM.Checked = true;
            if (op.Sexo == 'F')
                rbF.Checked = true;
            dtNacimiento.Value = op.FechaNacimiento.Date;
            txtEdad.Text = op.Edad.ToString();
            txtCiudad.Text = op.Ciudad;
            txtDirec.Text = op.Direccion;
            txtCelu.Text = op.Celular;
            txtEmail.Text = op.Email;


        }

        public Adoptante CrearObjeto()
        {
            string id = txtId.Text;
            string identificacion = txtIdent.Text;
            string nombres = txtNombres.Text;
            string ape = txtApellidos.Text;
            char sexo = ' ';
            if (rbF.Checked == true)
            {
                sexo = 'F';
            }
            else if (rbM.Checked == true)
            {
                sexo = 'M';
            }
            DateTime fNac = dtNacimiento.Value;
            int edad = int.Parse(txtEdad.Text);
            string ciudad = txtCiudad.Text;
            string direc = txtDirec.Text;
            string cel = txtCelu.Text;
            string email = txtEmail.Text;

            return new Adoptante(id, identificacion, nombres, ape, sexo, fNac, edad, ciudad, direc, cel, email);
        }






        public bool ValidarDatos()
        {
            bool val = true;
            string cod = txtId.Text;
            if (banActualizar == false)
            {
                val = existeCodigo(cod);
            }
            if (txtId.Text.Trim().Length == 0 || txtIdent.Text.Trim().Length == 0 || txtNombres.Text.Trim().Length == 0
                || txtApellidos.Text.Trim().Length == 0 || txtCiudad.Text.Trim().Length == 0 || txtEdad.Text.Trim().Length == 0 ||
                txtDirec.Text.Trim().Length == 0 || txtCelu.Text.Trim().Length == 0 || txtEmail.Text.Trim().Length == 0)
            {
                val = false;

            }


            return val;
        }
        public void Guardar()
        {
            try
            {
                //int codigoprovedor = int.Parse(txtCodigo.Text);
                //var sql = from le in pcp.ViewProductoCategoriaFiltro("") where le.IdProducto == codigoprovedor select le;

                if (ValidarDatos())
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
                MessageBox.Show("Ingrese correctamente los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditAdoptante_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guardar();
        }


        private void dtNacimiento_ValueChanged(object sender, EventArgs e)
        {
            DateTime today;
            today = DateTime.Now;

            int años = today.Year - dtNacimiento.Value.Year;
            if (today.Month < dtNacimiento.Value.Month || (today.Month == dtNacimiento.Value.Month &&
            today.Day < dtNacimiento.Value.Day))
                años--;

            txtEdad.Text = años.ToString();
        }
    }
}
