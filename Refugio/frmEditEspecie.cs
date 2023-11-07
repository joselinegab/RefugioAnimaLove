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
    public partial class frmEditEspecie : Form
    {
        public frmEditEspecie()
        {
            InitializeComponent();
        }
        EspecieLN pln = new EspecieLN();
        public bool banActualizar;

        public bool existeCodigo(string cod)
        {
            Especie op = pln.GetIdEspecie(cod);
            if (op != null)
            {
                MessageBox.Show($"El código {cod} ya existe", "Código repetido");
                return false;
            }
            else
                return true;
        }

        public void CargarDatos(Especie op)
        {
            txtTipo.Text = op.Nombre;
            txtDescrip.Text = op.Descripcion;

        }

        public Especie CrearObjeto()
        {
            string tip = txtTipo.Text;
            string des = txtDescrip.Text;

            return new Especie(tip, des);
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
                MessageBox.Show(this, ex.Message);
            }
        }
        private void frmEditEspecie_Load(object sender, EventArgs e)
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
