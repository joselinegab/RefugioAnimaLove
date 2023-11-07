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
    public partial class frmEditTipoPersonal : Form
    {
        public frmEditTipoPersonal()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
 
        TipoPersonalLN pln = new TipoPersonalLN();
        public bool banActualizar;

        public bool existeCodigo(string cod)
        {
            TipoPersonal op = pln.GetIdTipoPersonal(cod);
            if (op != null)
            {
                MessageBox.Show($"El código {cod} ya existe", "Código repetido");

                return false;
            }
            else
                return true;
        }

        public void CargarDatos(TipoPersonal op)
        {
            txtTipo.Text = op.Tipo;
            txtDescrip.Text = op.Descripcion;

        }

        public TipoPersonal CrearObjeto()
        {
            string tip = txtTipo.Text;
            string des = txtDescrip.Text;

            return new TipoPersonal(tip,des);
        }

        public bool validarEntradas()
        {
            bool val = true;
            string cod = txtTipo.Text;
            if (banActualizar == false)
            {
                val = existeCodigo(cod);
            }
            if (txtTipo.Text.Trim().Length == 0)
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

                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditTipoPersonal_Load(object sender, EventArgs e)
        {

        }
    }
}
