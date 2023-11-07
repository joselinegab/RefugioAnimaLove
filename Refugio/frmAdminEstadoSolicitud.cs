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
    public partial class frmAdminEstadoSolicitud : Form
    {
        public frmAdminEstadoSolicitud()
        {
            InitializeComponent();
        }
        EstadoSolicitudLN opln = new EstadoSolicitudLN();

        //MÉTODOS PARA LISTAR: LISTAR TODO Y LISTAR POR INGRESO
        public void ListarEstadoSolicitudsFiltro(string dato)
        {
            dtgDatos.DataSource = opln.ViewEstadoSolicitudFiltro(dato);
        }

        public void ListarEstadoSolicituds()
        {
            dtgDatos.DataSource = opln.ViewEstadoSolicitud();
        }

        public void Nuevo()
        {
            try
            {
                frmEditEstadoSolicitud frm = new frmEditEstadoSolicitud();
                frm.Text = "Ingresar estado de solicitud";
                frm.label3.Text = "Ingresar estado de solicitud";
                frm.banActualizar = false;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    EstadoSolicitud op = frm.CrearObjeto();
                    opln.CreateEstadoSolicitud(op);
                    frm.Close();
                    tEstado.Text = "Estado de solicitud ingresado";
                }
                else
                {
                    tEstado.Text = "Ingreso cancelado";
                }
                ListarEstadoSolicituds();
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al ingresar estado de solicitud";
            }
        }

        //MÉTODO PARA MODIFICAR UN DATO ESPECÍFICO SEGÚN SU ID
        public void Modificar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    frmEditEstadoSolicitud frm = new frmEditEstadoSolicitud();
                    frm.Text = "Actualizar estado de solicitud";
                    frm.label3.Text = "Actualizar estado de solicitud";
                    frm.banActualizar = true;
                    frm.txtNombre.Enabled = false;

                    EstadoSolicitud op = null;

                    op = dtgDatos.CurrentRow.DataBoundItem as EstadoSolicitud;

                    frm.CargarDatos(op);
                    frm.ShowDialog(this);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        op = frm.CrearObjeto();
                        opln.UpdateEstadoSolicitud(op);
                        frm.Close();
                        tEstado.Text = "Estado de solicitud actualizado";
                    }
                    else
                    {
                        tEstado.Text = "Actualización cancelada";
                    }
                        ListarEstadoSolicituds();
                    
                }
                else
                {
                    MessageBox.Show(this, "No existen datos");
                }
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al actualizar estado de solicitud";
            }
        }

        //MÉTODO PARA ELIMINAR UN DATO SELECCIONADO SEGÚN SU ID
        public void Eliminar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el estado seleccionado?", "Eliminar estado de solicitud", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        EstadoSolicitud op = dtgDatos.CurrentRow.DataBoundItem as EstadoSolicitud;
                        opln.DeleteEstadoSolicitud(op);
                        tEstado.Text = "Estado de solicitud eliminado";
                    }
                    else
                    {
                        tEstado.Text = "Eliminación cancelada";
                    }
                    ListarEstadoSolicituds();
                }
                else
                    MessageBox.Show(this, "Seleccione la fila a eliminar");
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al eliminar EstadoSolicitud";
            }
        }
        private void frmAdminEstadoSolicitud_Load(object sender, EventArgs e)
        {
            ListarEstadoSolicituds();
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
            ListarEstadoSolicitudsFiltro(txtBuscar.Text);
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
