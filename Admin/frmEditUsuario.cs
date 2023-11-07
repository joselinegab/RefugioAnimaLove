using CapaEntidades;
using CapaLogica.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefugioAnimaLove.Admin
{
    public partial class frmEditUsuario : Form
    {
        public frmEditUsuario()
        {
            InitializeComponent();
            this.CenterToScreen();
            Size = new Size(430,295); 
        }
        UsuarioLN pln = new UsuarioLN();
        public bool banActualizar;

        public bool existeCodigo(string cod)
        {
            Usuario op = pln.GetIdUsuario(cod);
            if (op != null)
            {
                MessageBox.Show($"El código {cod} ya existe", "Código repetido");
                return false;
            }
            else
                return true;
        }

        public void CargarDatos(Usuario op)
        {
            txtCod.Text = op.IdUsuario;
            txtUser.Text = op.User;
            txtPass.Text = op.Pass;

        }

        public Usuario CrearObjeto()
        {
            string codigo = txtCod.Text;
            string user = txtUser.Text;
            string pass = txtPass.Text;

            return new Usuario(codigo, user, pass);
        }

        public bool validarEntradas()
        {
            bool val = true;
            string cod = txtCod.Text;
            if (banActualizar == false)
            {
                val = existeCodigo(cod);
            }
            if (txtPass.Text.Trim().Length == 0 || txtUser.Text.Trim().Length == 0)
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
                    MessageBox.Show("Ingrese correctamente los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void frmEditUsuario_Load(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
