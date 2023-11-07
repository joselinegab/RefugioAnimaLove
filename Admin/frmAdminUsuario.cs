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
    public partial class frmAdminUsuario : Form
    {
        public frmAdminUsuario()
        {
            InitializeComponent();
        }
        UsuarioLN opln = new UsuarioLN();

        //MÉTODOS PARA LISTAR: LISTAR TODO Y LISTAR POR INGRESO
        public void ListarUsuariosFiltro(string dato)
        {
            dtgDatos.DataSource = opln.ViewUsuarioFiltro(dato);
        }

        public void ListarUsuarios()
        {
            dtgDatos.DataSource = opln.ViewUsuario();
        }
        private void frmAdminUsuario_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }
        public void Nuevo()
        {
            try
            {
                frmEditUsuario frm = new frmEditUsuario();
                frm.Text = "Ingresar usuario";
                frm.lblTitulo.Text = "Ingresar nuevo usuario";
                frm.banActualizar = false;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Usuario op = frm.CrearObjeto();
                    opln.CreateUsuario(op);
                    frm.Close();
                    tEstado.Text = "Usuario ingresado";
                }
                else
                {
                    tEstado.Text = "Ingreso cancelado";
                }
                ListarUsuarios();
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al ingresar usuario";
            }
        }

        //MÉTODO PARA MODIFICAR UN DATO ESPECÍFICO SEGÚN SU ID
        public void Modificar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    frmEditUsuario frm = new frmEditUsuario();
                    frm.Text = "Actualizar usuario";
                    frm.lblTitulo.Text = "Actualizar datos del usuario";
                    frm.banActualizar = true;
                    frm.txtCod.Enabled = false;

                    Usuario op = null;

                    op = dtgDatos.CurrentRow.DataBoundItem as Usuario;

                    frm.CargarDatos(op);
                    frm.ShowDialog(this);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        op = frm.CrearObjeto();
                        opln.UpdateUsuario(op);
                        frm.Close();
                        tEstado.Text = "Usuario actualizado";
                    }
                    else
                    {
                        tEstado.Text = "Actualización cancelada";
                    }
                    ListarUsuarios();
                }
                else
                {
                    tEstado.Text = "Seleccione un usuario";
                }
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al modificar usuario";
            }
        }

        //MÉTODO PARA ELIMINAR UN DATO SELECCIONADO SEGÚN SU ID
        public void Eliminar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el usuario seleccionado?", "Eliminar usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Usuario op = dtgDatos.CurrentRow.DataBoundItem as Usuario;
                        opln.DeleteUsuario(op);
                        tEstado.Text = "Usuario eliminado";
                    }
                    else
                    {
                        tEstado.Text = "Eliminación cancelada";
                    }
                        ListarUsuarios();
                    
                }
                else
                    MessageBox.Show(this, "Seleccione la fila a eliminar");
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al eliminar usuario";
            }
        }
     

        private void dtgUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            ListarUsuariosFiltro(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
