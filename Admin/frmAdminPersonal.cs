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
    public partial class frmAdminPersonal : Form
    {
        public frmAdminPersonal()
        {
            InitializeComponent();
        }
        
        PersonalLN opln = new PersonalLN();
        public int opc;

        //MÉTODOS PARA LISTAR: LISTAR TODO Y LISTAR POR INGRESO
        public void ListarPersonalsFiltro(string dato)
        {
            dtgDatos.DataSource = opln.ViewPersonalFiltro(dato);
        }

        public void ListarPersonals()
        {
            dtgDatos.DataSource = opln.ViewPersonal();
        }
      
        public void Nuevo()
        {
            opc = 1;
            try
            {
                frmEditPersonal frm = new frmEditPersonal();
                frm.Text = "Registrar personal";
                frm.lblTitulo.Text = "Registrar nuevo personal";
                frm.banActualizar = false;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Personal op = frm.CrearObjeto();
                    opln.CreatePersonal(op);
                    frm.Close();
                    tEstado.Text = "Personal ingresado";
                }
                else
                {
                    frm.Close();
                    tEstado.Text = "Ingreso cancelado";
                }
                ListarPersonals();
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al ingresar personal";
            }
        }


        public void Modificar()
        {
            opc = 2;
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    frmEditPersonal frm = new frmEditPersonal();
                    frm.Text = "Actualizar datos del personal";
                    frm.lblTitulo.Text = "Actualizar datos del personal";
                    frm.banActualizar = true;
                    Personal op = null;
                    frm.txtId.Enabled = false;
                    op = dtgDatos.CurrentRow.DataBoundItem as Personal;

                    frm.CargarDatos(op);
                    frm.ShowDialog(this);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        op = frm.CrearObjeto();
                        opln.UpdatePersonal(op);
                        frm.Close();
                        ListarPersonals();
                        tEstado.Text = "Personal actualizado";

                    }
                    else
                    {
                        tEstado.Text = "Actualización cancelada";
                    }
                    ListarPersonals();

                }
                else
                {
                    tEstado.Text = "Seleccione personal";
                }
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al modificar personal";
            }
        }

        //MÉTODO PARA ELIMINAR UN DATO SELECCIONADO SEGÚN SU ID
        public void Eliminar()
        {
            opc = 3;
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el personal seleccionado?", "Eliminar Personal", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Personal op = dtgDatos.CurrentRow.DataBoundItem as Personal;
                        opln.DeletePersonal(op);
                        ListarPersonals();
                        tEstado.Text = "Personal eliminado";

                    }
                    else
                    {
                        tEstado.Text = "Eliminación cancelada";
                    }
                }
                else
                    MessageBox.Show(this, "Seleccione la fila a eliminar");
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al eliminar personal";
            }
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
            ListarPersonalsFiltro(txtBuscar.Text);
        }

        private void frmAdminPersonal_Load(object sender, EventArgs e)
        {
            ListarPersonals();
        }

        private void dtgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
