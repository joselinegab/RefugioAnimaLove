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
    public partial class frmAdminTipoPersonal : Form
    {
        public frmAdminTipoPersonal()
        {
            InitializeComponent();
        }
        TipoPersonalLN opln = new TipoPersonalLN();

        //MÉTODOS PARA LISTAR: LISTAR TODO Y LISTAR POR INGRESO
        public void ListarTipoPersonalsFiltro(string dato)
        {
            dtgDatos.DataSource = opln.ViewTipoPersonalFiltro(dato);
        }

        public void ListarTipoPersonals()
        {
            dtgDatos.DataSource = opln.ViewTipoPersonal();
        }
        public void Nuevo()
        {
            try
            {
                frmEditTipoPersonal frm = new frmEditTipoPersonal();
                frm.Text = "Ingresar tipo de personal";
                frm.lblTitulo.Text = "Ingresar tipo de personal";
                frm.banActualizar = false;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    TipoPersonal op = frm.CrearObjeto();
                    opln.CreateTipoPersonal(op);
                    frm.Close();
                    tEstado.Text = "Tipo de personal ingresado";
                }
                else
                {
                    frm.Close();
                    tEstado.Text = "Ingreso cancelado";
                }
                ListarTipoPersonals();
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al ingresar tipo de personal";
            }
        }

        //MÉTODO PARA MODIFICAR UN DATO ESPECÍFICO SEGÚN SU ID
        public void Modificar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    frmEditTipoPersonal frm = new frmEditTipoPersonal();
                    frm.Text = "Actualizar tipo de personal";
                    frm.lblTitulo.Text = "Actualizar tipo de personal";
                    frm.banActualizar = true;
                    frm.txtTipo.Enabled = false;
                    TipoPersonal op = null;

                    op = dtgDatos.CurrentRow.DataBoundItem as TipoPersonal;

                    frm.CargarDatos(op);
                    frm.ShowDialog(this);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        op = frm.CrearObjeto();
                        opln.UpdateTipoPersonal(op);
                        frm.Close();
                        tEstado.Text = "Tipo de personal actualizado";
                    }
                    else
                    {
                        tEstado.Text = "Actualización cancelada";
                    }
                    ListarTipoPersonals();
                }
                else
                {
                    tEstado.Text = "Seleccione un tipo de personal";
                }
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al modificar tipo de personal";
            }
        }

        //MÉTODO PARA ELIMINAR UN DATO SELECCIONADO SEGÚN SU ID
        public void Eliminar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el tipo de personal seleccionado?", "Eliminar tipo de personal", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        TipoPersonal op = dtgDatos.CurrentRow.DataBoundItem as TipoPersonal;
                        opln.DeleteTipoPersonal(op);
                        tEstado.Text = "Tipo de personal eliminado";
                    }
                    else
                    {
                        tEstado.Text = "Eliminación cancelada";
                    }
                    ListarTipoPersonals();
                }
                else
                    MessageBox.Show(this, "Seleccione la fila a eliminar");
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al eliminar tipo de personal";
            }
        }
        private void frmAdminTipoPersonal_Load(object sender, EventArgs e)
        {
            ListarTipoPersonals();
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
            ListarTipoPersonalsFiltro(txtBuscar.Text);
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
