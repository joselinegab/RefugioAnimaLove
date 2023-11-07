using CapaEntidades;
using CapaLogica.Refugio;
using RefugioAnimaLove.Personalizadas;
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
    public partial class frmAdminAdoptante : Form
    {
        public frmAdminAdoptante()
        {
            InitializeComponent();
            Size = new Size(790, 576);
            this.CenterToParent();

        }
        AdoptanteLN opln = new AdoptanteLN();
        //public Adoptante aux;


        //MÉTODOS PARA LISTAR: LISTAR TODO Y LISTAR POR INGRESO
        public void ListarAdoptantesFiltro(string dato)
        {
            dtgDatoss.DataSource = opln.ViewAdoptanteFiltro(dato);
        }

        public void ListarAdoptantes()
        {
            dtgDatoss.DataSource = opln.ViewAdoptante();
        }
        public void GetAdop (string val)
        {
            opln.GetIdAdoptante(val);
        }
        public void Nuevo()
        {
            try
            {
                frmEditAdoptante frm = new frmEditAdoptante();
                frm.Text = "Registrar adoptante";
                frm.label3.Text = "Registrar adoptante";
                frm.banActualizar = false;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Adoptante op = frm.CrearObjeto();
                    opln.CreateAdoptante(op);
                    frm.Close();
                    tEstado.Text = "Adoptante ingresado";
                }
                else
                {
                    tEstado.Text = "Ingreso cancelado";
                }
                ListarAdoptantes();
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al ingresar Adoptante";
            }
        }

        //MÉTODO PARA MODIFICAR UN DATO ESPECÍFICO SEGÚN SU ID
        public void Modificar()
        {
            try
            {
                if (dtgDatoss.CurrentRow != null)
                {
                    frmEditAdoptante frm = new frmEditAdoptante();
                    frm.Text = "Actualizar adoptante";
                    frm.label3.Text = "Actualizar datos del adoptante";
                    frm.banActualizar = true;
                    frm.txtId.Enabled = false;


                    Adoptante op = null;

                    op = dtgDatoss.CurrentRow.DataBoundItem as Adoptante;

                    frm.CargarDatos(op);
                    frm.ShowDialog(this);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        op = frm.CrearObjeto();
                        opln.UpdateAdoptante(op);
                        frm.Close();
                        ListarAdoptantes();
                        tEstado.Text = "Datos del adoptante actualizados";

                    }
                    else
                    {
                        tEstado.Text = "Actualización cancelada";
                    }
                }
                else
                {
                    tEstado.Text = "Seleccione un adoptante";
                }
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al actualizar adoptante";
            }
        }

        //MÉTODO PARA ELIMINAR UN DATO SELECCIONADO SEGÚN SU ID
        public void Eliminar()
        {
            try
            {
                if (dtgDatoss.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el adoptante seleccionado?", "Eliminar Adoptante", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Adoptante op = dtgDatoss.CurrentRow.DataBoundItem as Adoptante;
                        opln.DeleteAdoptante(op);
                        ListarAdoptantes();
                        tEstado.Text = "Adoptante eliminado";
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
                tEstado.Text = "Error al eliminar adoptante";
            }
        }
        public void CrearSolicitud()
        {
            try
            {
                if (dtgDatoss.CurrentRow != null)
                {

                    var res = MessageBox.Show("¿Desea crear una solicitud con los datos de este adoptante?", "Seleccionar adoptante", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {

                        string idAdop = dtgDatoss.CurrentRow.Cells[0].Value.ToString();
                        string cedula = dtgDatoss.CurrentRow.Cells[1].Value.ToString();
                        string nombres = dtgDatoss.CurrentRow.Cells[2].Value.ToString();
                        string apellidos = dtgDatoss.CurrentRow.Cells[3].Value.ToString();
                        string direc = dtgDatoss.CurrentRow.Cells[8].Value.ToString();
                        string ciud = dtgDatoss.CurrentRow.Cells[7].Value.ToString();
                        int edad = int.Parse(dtgDatoss.CurrentRow.Cells[6].Value.ToString());
                        string celu = dtgDatoss.CurrentRow.Cells[9].Value.ToString();
                        string email = dtgDatoss.CurrentRow.Cells[10].Value.ToString();

                        frmEditSolicitud g = new frmEditSolicitud();
                        //frmEditSolicitud g = Application.OpenForms["frmEditSolicitud"] as frmEditSolicitud;
                        g.banActualizar = false;
                        g.aux = dtgDatoss.CurrentRow.DataBoundItem as Adoptante; ;
                        g.txtIdAdop.Text = idAdop;
                        g.txtIdentif.Text = cedula;
                        g.txtNombres.Text = nombres;
                        g.txtApes.Text = apellidos;
                        g.txtEdadd.Text = edad.ToString();
                        g.txtCiu.Text = ciud;
                        g.txtDirec.Text = direc;
                        g.txtCelu.Text = celu;
                        g.txtEmail.Text = email;
                        //g.btnBuscarAni.Visible = false;
                        g.btnBuscarAdop.Visible = false;
                        g.ShowDialog();

                        //tEstado.Text = "Datos ingresados correctamente";
                        //this.Close();
                    }
                    else
                        tEstado.Text = "Selección cancelada";
                }
                else
                    tEstado.Text = " Seleccione la fila a eliminar";
            }
            catch (Exception ex)
            {
                tEstado.Text = " Error al seleccionar adoptante";
            }

        }
        public void Seleccionar()
        {
            try
            {
                if (dtgDatoss.CurrentRow != null)
                {

                    var res = MessageBox.Show("¿Desea seleccionar este adoptante?", "Seleccionar adoptante", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {

                        string idAdop = dtgDatoss.CurrentRow.Cells[0].Value.ToString();
                        string cedula = dtgDatoss.CurrentRow.Cells[1].Value.ToString();
                        string nombres = dtgDatoss.CurrentRow.Cells[2].Value.ToString();
                        string apellidos = dtgDatoss.CurrentRow.Cells[3].Value.ToString();
                        string direc = dtgDatoss.CurrentRow.Cells[8].Value.ToString();
                        string ciud = dtgDatoss.CurrentRow.Cells[7].Value.ToString();
                        int edad = int.Parse(dtgDatoss.CurrentRow.Cells[6].Value.ToString());
                        string celu = dtgDatoss.CurrentRow.Cells[9].Value.ToString();
                        string email = dtgDatoss.CurrentRow.Cells[10].Value.ToString();

                        //frmEditSolicitud g = new frmEditSolicitud();
                        frmEditSolicitud g = Application.OpenForms["frmEditSolicitud"] as frmEditSolicitud;
                        g.banActualizar = false;
                        g.aux = dtgDatoss.CurrentRow.DataBoundItem as Adoptante;
                        g.txtIdAdop.Text = idAdop;
                        g.txtIdentif.Text = cedula;
                        g.txtNombres.Text = nombres;
                        g.txtApes.Text = apellidos;
                        g.txtEdadd.Text = edad.ToString();
                        g.txtCiu.Text = ciud;
                        g.txtDirec.Text = direc;
                        g.txtCelu.Text = celu;
                        g.txtEmail.Text = email;
                        //g.ShowDialog();

                        //tEstado.Text = "Datos ingresados correctamente";
                        this.Close();
                    }
                    else
                        tEstado.Text = "Selección cancelada";
                }
                else
                    tEstado.Text = " Seleccione la fila a eliminar";
            }
            catch (Exception ex)
            {
                tEstado.Text = " Error al seleccionar adoptante";
            }

        }
        private void frmAdminAdoptante_Load(object sender, EventArgs e)
        {
            ListarAdoptantes();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListarAdoptantesFiltro(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSolicitud_Click(object sender, EventArgs e)
        {
            CrearSolicitud();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void label2_Click(object sender, EventArgs e)
        {
   
            if (dtgDatoss.CurrentRow != null)
            {
                frmAdminSolicitudAdopcion frm = new frmAdminSolicitudAdopcion();
                frm.aux2 = dtgDatoss.CurrentRow.DataBoundItem as Adoptante;
                frm.btnInsertar2.Visible = false;
                frm.btnInsertar2.Visible = false;
                frm.btnEliminar.Visible = false;
                frm.btnEditar.Visible = false;
                frm.label3.Visible = false;
                frm.btnver.Visible = true;
                //frm.btnver.Visible = false;

                frm.ver = true;
                frm.ShowDialog();
            }
            else
            {
                tEstado.Text = "No existen datos o no se ha seleccionado una fila";
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
