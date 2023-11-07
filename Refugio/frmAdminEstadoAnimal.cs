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
    public partial class frmAdminEstadoAnimal : Form
    {
        public frmAdminEstadoAnimal()
        {
            InitializeComponent();
        }
        EstadoAnimalLN opln = new EstadoAnimalLN();

        //MÉTODOS PARA LISTAR: LISTAR TODO Y LISTAR POR INGRESO
        public void ListarEstadoAnimalsFiltro(string dato)
        {
            dtgDatos.DataSource = opln.ViewEstadoAnimalFiltro(dato);
        }

        public void ListarEstadoAnimals()
        {
            dtgDatos.DataSource = opln.ViewEstadoAnimal();
        }

        public void Nuevo()
        {
            try
            {
                frmEditEstadoAnimal frm = new frmEditEstadoAnimal();
                frm.Text = "Ingresar estado de animal";
                frm.label3.Text = "Ingresar estado de animal";
                frm.banActualizar = false;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    EstadoAnimal op = frm.CrearObjeto();
                    opln.CreateEstadoAnimal(op);
                    frm.Close();
                    tEstado.Text = "Estado de animal ingresado";
                }
                else
                {
                    tEstado.Text = "Ingreso cancelado";
                }
                ListarEstadoAnimals();
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al ingresar estado de animal";
            }
        }

        //MÉTODO PARA MODIFICAR UN DATO ESPECÍFICO SEGÚN SU ID
        public void Modificar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    frmEditEstadoAnimal frm = new frmEditEstadoAnimal();
                    frm.Text = "Actualizar estado de animal";
                    frm.label3.Text = "Actualizar estado de animal";
                    frm.banActualizar = true;
                    frm.txtNombre.Enabled = false;

                    EstadoAnimal op = null;

                    op = dtgDatos.CurrentRow.DataBoundItem as EstadoAnimal;

                    frm.CargarDatos(op);
                    frm.ShowDialog(this);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        op = frm.CrearObjeto();
                        opln.UpdateEstadoAnimal(op);
                        frm.Close();
                        tEstado.Text = "Estado de animal actualizado";
                    }
                    else
                    {
                        tEstado.Text = "Actualización cancelada";

                    }
                    ListarEstadoAnimals();
                    
                }
                else
                {
                    MessageBox.Show(this, "No existen datos");
                }
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al actualizar estado de animal";
            }
        }

        //MÉTODO PARA ELIMINAR UN DATO SELECCIONADO SEGÚN SU ID
        public void Eliminar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el estado seleccionado?", "Eliminar Estado de Animal", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        EstadoAnimal op = dtgDatos.CurrentRow.DataBoundItem as EstadoAnimal;
                        opln.DeleteEstadoAnimal(op);
                        tEstado.Text = "Estado de animal eliminado";
                    }
                    else
                    {
                        tEstado.Text = "Eliminación cancelada";
                    }
                        ListarEstadoAnimals();
                    
                }
                else
                    MessageBox.Show(this, "Seleccione la fila a eliminar");
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al eliminar estado de animal";
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
            ListarEstadoAnimalsFiltro(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdminEstadoAnimal_Load(object sender, EventArgs e)
        {
            
            ListarEstadoAnimals();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
