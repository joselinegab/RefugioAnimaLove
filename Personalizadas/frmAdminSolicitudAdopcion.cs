using CapaEntidades;
using CapaEntidades.Clases_personalizadas;
using CapaLogica.Clases_personalizadas;
using CapaLogica.Refugio;
using RefugioAnimaLove.Refugio;
using RefugioAnimaLove.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefugioAnimaLove.Personalizadas
{
    public partial class frmAdminSolicitudAdopcion : Form
    {
        public frmAdminSolicitudAdopcion()
        {
            InitializeComponent();
            Size = new Size(750, 600);

        }
        SolicitudAdopcionLN opln = new SolicitudAdopcionLN();
        SolicitudLN soli = new SolicitudLN();
        AdoptanteLN adop = new AdoptanteLN();
        AnimalLN ani = new AnimalLN();

        public Animal aux1;
        public Adoptante aux2;
        public string idAdop;

        public bool banActualizar;
        public bool ver;
        public void ListarSolicitudAdopcionsFiltro(string dato)
        {
            dtgDatos.DataSource = opln.ViewSolicitudAdopcionFiltro(dato);
        }
        public void ListarSolicitudAdopcionsFiltroXAdop(string dato)
        {
            dtgDatos.DataSource = opln.ViewSolicitudAdopcionFiltroXAdoptante(dato);
        }

        public void ListarSolicitudAdopcions()
        {
            dtgDatos.DataSource = opln.ViewSolicitudAdopcion();
        }
        //CUANDO SE INGRESA DESDE EL ADMIN
        public void Nuevo()
        {
            try
            {
                //frmAdminAdoptante frm = new frmAdminAdoptante();
                //frm.label1.Text = "Seleccione adoptante";
                //frm.ShowDialog();
                frmEditSolicitud frm = new frmEditSolicitud();
                frm.Text = "Ingresar solicitud de adopción";
                frm.label3.Text = "Nueva solicitud de adopción";
                frm.banActualizar = false;
                frm.op = 1;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Solicitud op = frm.CrearObjeto();
                    soli.CreateSolicitud(op);
                    frm.Close();
                    tEstado.Text = "Solicitud ingresada";
                }
                else
                {
                    tEstado.Text = "Ingreso cancelado";
                }
                ListarSolicitudAdopcions();

                //if (ver)
                //{
                //    ListarSolicitudAdopcionsFiltroXAdop(aux2.Identificacion);
                //}
                //else
                //{
                //    ListarSolicitudAdopcions();
                //}
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al ingresar solicitud de adopción";
            }
        }
        //CUANDO SE INGRESA DESDE ADOPTANTES
        public void Nuevo2()
        {
            try
            {
                frmEditSolicitud frm = new frmEditSolicitud();
                frm.Text = "Ingresar solicitud de adopción";
                frm.label3.Text = "Nueva solicitud de adopción";
                frm.banActualizar = false;
                frm.op = 1;
                frm.txtIdAdop.Text = aux2.IdAdoptante;
                frm.txtIdentif.Text = aux2.Identificacion;
                frm.txtNombres.Text = aux2.Nombres;
                frm.txtApes.Text = aux2.Apellidos;
                frm.txtEdadd.Text = aux2.Edad.ToString();
                frm.txtCiu.Text = aux2.Ciudad;
                frm.txtDirec.Text = aux2.Direccion;
                frm.txtCelu.Text = aux2.Celular;
                frm.txtEmail.Text = aux2.Email;
                frm.btnBuscarAdop.Visible = false;

                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Solicitud op = frm.CrearObjeto();
                    soli.CreateSolicitud(op);
                    frm.Close();
                    tEstado.Text = "Solicitud ingresada";
                }
                else
                {
                    tEstado.Text = "Ingreso cancelado";
                }

                ListarSolicitudAdopcionsFiltroXAdop(aux2.Identificacion);
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al ingresar solicitud de adopción";
            }
        }

        //MÉTODO PARA MODIFICAR UN DATO ESPECÍFICO SEGÚN SU ID
        public void Modificar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    frmEditSolicitud frm = new frmEditSolicitud();
                    frm.Text = "Actualizar solicitud de adopción";
                    frm.label3.Text = "Actualizar datos de la solicitud";
                    frm.banActualizar = true;
                    frm.op = 2;
                    frm.txtId.Enabled = false;

                    if (ver)
                    {
                        frm.btnBuscarAdop.Visible = false;
                    }
                    SolicitudAdopcion op = null;

                    op = dtgDatos.CurrentRow.DataBoundItem as SolicitudAdopcion;

                    Solicitud op2 = null;

                    op2 = dtgDatos.CurrentRow.DataBoundItem as Solicitud;
                    frm.CargarDatos(op);
                    frm.ShowDialog(this);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        op2 = frm.CrearObjeto();
                        soli.UpdateSolicitud(op2);
                        frm.Close();
                        tEstado.Text = "Solicitud actualizada";
                    }
                    else
                    {
                        tEstado.Text = "Actualización cancelada";
                    }
                    if (ver)
                    {
                        ListarSolicitudAdopcionsFiltroXAdop(aux2.Identificacion);
                    }
                    else
                    {

                        ListarSolicitudAdopcions();

                    }
                }
                else
                {
                    MessageBox.Show(this, "No se han encontrado datos");
                }
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al modificar la solicitud seleccionada";
            }
        }

        //MÉTODO PARA ELIMINAR UN DATO SELECCIONADO SEGÚN SU ID
        public void Eliminar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar la solicitud seleccionada?", "Eliminar solicitud de adopción", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //string idAni = dtgDatos.CurrentRow.Cells[2].Value.ToString();
                        SolicitudAdopcion op2 = dtgDatos.CurrentRow.DataBoundItem as SolicitudAdopcion;
                        aux1 = ani.GetIdAnimal(op2.IdAnimal);
                        aux1.EstadoAnimal = "Disponible";
                        ani.UpdateAnimal(aux1);
                        soli.DeleteSolicitudXId(op2.IdSolicitud);
                        tEstado.Text = "Solicitud eliminada";
                    }
                    else
                    {
                        tEstado.Text = "Eliminación cancelada";
                    }
                    if (ver)
                    {
                        ListarSolicitudAdopcionsFiltroXAdop(aux2.Identificacion);
                    }
                    else
                    {

                        ListarSolicitudAdopcions();

                    }
                }
                else
                    MessageBox.Show(this, "Seleccione la fila a eliminar");
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al eliminar solicitud de adopción";
            }
        }

        private void frmAdminSolicitudAdopcion_Load(object sender, EventArgs e)
        {
            if (ver)
            {
                ListarSolicitudAdopcionsFiltroXAdop(aux2.Identificacion);
            }
            else
            {

                ListarSolicitudAdopcions();

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListarSolicitudAdopcionsFiltro(txtBuscar.Text);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertar2_Click(object sender, EventArgs e)
        {
            Nuevo2();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (dtgDatos.CurrentRow != null)
            {
                if (MessageBox.Show("¿Está seguro que desea generar la solicitud seleccionada?", "Generar solicitud de adopción", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //string idAni = dtgDatos.CurrentRow.Cells[2].Value.ToString();
                    frmSolicitud frm = new frmSolicitud();
                    SolicitudAdopcion op2 = dtgDatos.CurrentRow.DataBoundItem as SolicitudAdopcion;
                    frm.a = ani.GetIdAnimal(op2.IdAnimal);
                    frm.ShowDialog();
                    //tEstado.Text = "Solicitud eliminada";
                }
                else
                {
                    tEstado.Text = "Generación cancelada";
                }
            }

        }

        private void btnver_Click(object sender, EventArgs e)
        {
            if (dtgDatos.CurrentRow != null)
            {
                frmEditSolicitud frm = new frmEditSolicitud();
                SolicitudAdopcion op = null;

                op = dtgDatos.CurrentRow.DataBoundItem as SolicitudAdopcion;
                frm.CargarDatos(op);
                frm.txtId.ReadOnly = true;
                frm.dtFecha.Enabled = false;
                frm.cmbEstado.Enabled = false;
                frm.btnBuscarAdop.Visible = false;
                frm.btnBuscarAni.Visible = false;

                frm.ShowDialog(this);
            }
            else
            {
                tEstado.Text = "No existen datos o no se ha seleccionado una fila";
            }
        }
    }
}
