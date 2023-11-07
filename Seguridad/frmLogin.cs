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

namespace RefugioAnimaLove.Seguridad
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        UsuarioLN opln = new UsuarioLN();
        Usuario aux;
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        public bool validarEntradas()
        {
            bool ok = false;
            aux = opln.GetIdUsuario(txtUser.Text);
            if (aux == null)
            {
                ok = false;
            }
            else if (txtPass.Text==aux.Pass && txtUser.Text == aux.User)
            {
                ok = true;
            }
            return ok;
        }
        private void button1_Click(object sender, EventArgs e)
        {
                if (validarEntradas())
                {
                    frmInicio frm = new frmInicio();
                    this.Hide();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
