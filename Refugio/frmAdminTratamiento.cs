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
    public partial class frmAdminTratamiento : Form
    {
        public frmAdminTratamiento()
        {
            InitializeComponent();
        }
        TratamientoLN opln = new TratamientoLN();

        //MÉTODOS PARA LISTAR: LISTAR TODO Y LISTAR POR INGRESO
        public void ListarTratamientosFiltro(string dato)
        {
            dtgDatos.DataSource = opln.ViewTratamientoFiltro(dato);
        }

        public void ListarTratamientos()
        {
            dtgDatos.DataSource = opln.ViewTratamiento();
        }

        public void Nuevo()
        {
            try
            {
                frmEditTratamiento frm = new frmEditTratamiento();
                frm.Text = "Ingresar tratamiento";
                frm.label3.Text = "Ingresar tratamiento";
                frm.banActualizar = false;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Tratamiento op = frm.CrearObjeto();
                    opln.CreateTratamiento(op);
                    frm.Close();
                    tEstado.Text = "Tratamiento ingresado";
                }
                else
                {
                    tEstado.Text = "Ingreso cancelado";
                }
                ListarTratamientos();
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al ingresar tratamiento";
            }
        }

        //MÉTODO PARA MODIFICAR UN DATO ESPECÍFICO SEGÚN SU ID
        public void Modificar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    frmEditTratamiento frm = new frmEditTratamiento();
                    frm.Text = "Actualizar tratamiento";
                    frm.label3.Text = "Actualizar datos del tratamiento";
                    frm.banActualizar = true;
                    frm.txtNombre.Enabled = false;

                    Tratamiento op = null;

                    op = dtgDatos.CurrentRow.DataBoundItem as Tratamiento;

                    frm.CargarDatos(op);
                    frm.ShowDialog(this);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        op = frm.CrearObjeto();
                        opln.UpdateTratamiento(op);
                        frm.Close();
                        tEstado.Text = "Datos del tratamiento actualizados";
                    }
                    else
                    {
                        tEstado.Text = "Actualización cancelada";
                    }
                        ListarTratamientos();
                }
                else
                {
                    MessageBox.Show(this, "Seleccione una fila");
                }
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al actualizar tratamiento";
            }
        }

        //MÉTODO PARA ELIMINAR UN DATO SELECCIONADO SEGÚN SU ID
        public void Eliminar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el tratamiento seleccionado?", "Eliminar Tratamiento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Tratamiento op = dtgDatos.CurrentRow.DataBoundItem as Tratamiento;
                        opln.DeleteTratamiento(op);
                        tEstado.Text = "Tratamiento eliminado";
                    }
                    else
                    {
                        tEstado.Text = "Eliminación cancelada";
                    }
                        ListarTratamientos();
                }
                else
                    MessageBox.Show(this, "Seleccione la fila a eliminar");
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al eliminar Tratamiento";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAdminTratamiento_Load(object sender, EventArgs e)
        {
            ListarTratamientos();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListarTratamientosFiltro(txtBuscar.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
