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
    public partial class frmAdminEspecie : Form
    {
        public frmAdminEspecie()
        {
            InitializeComponent();
        }
        EspecieLN opln = new EspecieLN();

        //MÉTODOS PARA LISTAR: LISTAR TODO Y LISTAR POR INGRESO
        public void ListarEspeciesFiltro(string dato)
        {
            dtgDatos.DataSource = opln.ViewEspecieFiltro(dato);
        }

        public void ListarEspecies()
        {
            dtgDatos.DataSource = opln.ViewEspecie();
        }
  
        public void Nuevo()
        {
            try
            {
                frmEditEspecie frm = new frmEditEspecie();
                frm.Text = "Ingresar especie";
                frm.label3.Text = "Ingresar especie";
                frm.banActualizar = false;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Especie op = frm.CrearObjeto();
                    opln.CreateEspecie(op);
                    frm.Close();
                    tEstado.Text = "Especie ingresada";
                }
                else
                {
                    tEstado.Text = "Ingreso cancelado";
                }
                ListarEspecies();
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al ingresar especie";
            }
        }

        //MÉTODO PARA MODIFICAR UN DATO ESPECÍFICO SEGÚN SU ID
        public void Modificar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    frmEditEspecie frm = new frmEditEspecie();
                    frm.Text = "Actualizar especie";
                    frm.label3.Text = "Actualizar datos de especie";
                    frm.banActualizar = true;
                    frm.txtTipo.Enabled = false;

                    Especie op = null;

                    op = dtgDatos.CurrentRow.DataBoundItem as Especie;

                    frm.CargarDatos(op);
                    frm.ShowDialog(this);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        op = frm.CrearObjeto();
                        opln.UpdateEspecie(op);
                        frm.Close();
                        tEstado.Text = "Datos de especie actualizados";
                    }
                    else
                    {
                        tEstado.Text = "Actualización cancelada";
                    }
                    ListarEspecies();
                }
                else
                {
                    MessageBox.Show(this, "No existen datos");
                }
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al actualizar especie";
            }
        }

        //MÉTODO PARA ELIMINAR UN DATO SELECCIONADO SEGÚN SU ID
        public void Eliminar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar la especie seleccionada?", "Eliminar especie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Especie op = dtgDatos.CurrentRow.DataBoundItem as Especie;
                        opln.DeleteEspecie(op);
                        tEstado.Text = "Especie eliminada";
                    }
                    else
                    {
                        tEstado.Text = "Eliminación cancelada";
                    }
                        ListarEspecies();
                }
                else
                    MessageBox.Show(this, "Seleccione la fila a eliminar");
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al eliminar especie";
            }
        }
        private void frmAdminEspecie_Load(object sender, EventArgs e)
        {
            ListarEspecies();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListarEspeciesFiltro(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
