using CapaEntidades;
using CapaEntidades.Clases_personalizadas;
using CapaLogica.Clases_personalizadas;
using CapaLogica.Refugio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefugioAnimaLove.Refugio
{
    public partial class frmEditSolicitud : Form
    {
        public frmEditSolicitud()
        {
            InitializeComponent();
            Size = new Size(588, 660);
            this.CenterToScreen();
        }
        public Adoptante aux;
        SolicitudLN opln = new SolicitudLN();
        SolicitudAdopcionLN pln = new SolicitudAdopcionLN();
        public bool banActualizar;


        public SolicitudAdopcion auxSoli;
        public Solicitud auxSolic;
        public Animal auxAni;
        public Animal auxAniAnterior;

        AnimalLN o = new AnimalLN();

        public string idanni;
        SolicitudAdopcion soli = new SolicitudAdopcion();

        public int op;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmAdminAnimal frm = new frmAdminAnimal();
            frm.btnNuevo.Enabled = false;
            frm.btnEditar.Enabled = false;
            frm.btnEliminar.Enabled = false;
            frm.btnSeleccionar.Enabled = true;
            frm.btnAggTrata.Enabled = false;
            //frm.ListarAnimalsFiltro("Disponible");
            frm.ShowDialog();
        }
        public bool existeCodigo(string cod)
        {
            Solicitud op = opln.GetIdSolicitud(cod);
            if (op != null)
            {
                MessageBox.Show($"El código {cod} ya existe", "Código repetido");
                return false;
            }
            else
                return true;
        }

        public void CargarDatos(SolicitudAdopcion op)
        {
            txtId.Text = op.IdSolicitud;
            dtFecha.Value = op.Fecha;
            txtIdAdop.Text = op.IdAdoptante;
            txtIdentif.Text = op.Identificacion;
            txtNombres.Text = op.Nombres;
            txtApes.Text = op.Apellidos;
            txtDirec.Text = op.Direccion;
            txtCelu.Text = op.Celular;
            txtEdadd.Text = op.EdadAdop.ToString();
            txtCiu.Text = op.Ciudad;
            txtEmail.Text = op.Email;

            txtIdAnimal.Text = op.IdAnimal.ToString();
            txtNombre.Text = op.Nombre;
            if (op.Sexo == 'H')
                rbH.Checked = true;
            if (op.Sexo == 'M')
                rbMM.Checked = true;
            txtEdad.Text = op.Edad;
            txtPeso.Text = op.Peso;
            if (op.Enfermo == "SI")
                rbsienfermo.Checked = true;
            if (op.Enfermo == "NO")
                rbnoenfermo.Checked = true;
            if (op.Esterilizado == "SI")
                rbsiester.Checked = true;
            if (op.Esterilizado == "NO")
                rbnoester.Checked = true;
            txtEnfermedad.Text = op.Enfermedad;
            txtVacus.Text = op.Vacunas;
            byte[] imagen = op.Foto;
            MemoryStream ms = new MemoryStream(imagen);
            ptbImagen.Image = Image.FromStream(ms);
            ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            cmbEstado.Text = op.Estado;

            //idanni = op.IdAnimal.ToString();
        }

        public Solicitud CrearObjeto()
        {
            string id = txtId.Text;
            DateTime fecha = dtFecha.Value;
            string estado = cmbEstado.Text;
            int idanim = int.Parse(txtIdAnimal.Text);
            string idadop = txtIdAdop.Text;

            return new Solicitud(id, fecha, estado, idanim, idadop);
        }

        public bool validarEntradas()
        {
            bool val = true;
            string cod = txtId.Text;
            if (banActualizar == false)
            {
                val = existeCodigo(cod);
            }
            if (txtId.Text.Trim().Length == 0 || txtIdAnimal.Text.Trim().Length == 0
                || txtIdAdop.Text.Trim().Length == 0)
            {
                val = false;
            }
            return val;
        }


        public void Guardar()
        {
            try
            {
                auxAni = o.GetIdAnimal(int.Parse(txtIdAnimal.Text));

                //Obtener el objeto aux tipo Animal por el text que muestra su ID
                if (validarEntradas())
                {

                    if (op == 1)
                    {
                        //Validaciones para cambiar el estado del animal según el estado de la solicitud
                        if (cmbEstado.Text == "En proceso")
                        {
                            auxAni.EstadoAnimal = "No disponible";

                        }
                        else if (cmbEstado.Text == "Aprobada")
                        {
                            auxAni.EstadoAnimal = "Adoptado";
                        }
                        if (cmbEstado.Text == "Anulada" || cmbEstado.Text == "Rechazada")
                        {
                            auxAni.EstadoAnimal = "Disponible";
                        }

                        //Actualizar animal
                        o.UpdateAnimal(auxAni);
                    }
                    else
                    {

                        //Obtener un objeto aux de solicitud
                        auxSolic = opln.GetIdSolicitud(txtId.Text);

                        //Obtener un objeto aux ANIMAL ANTERIOR para cambiar
                        //su estado en caso de que se cambie de animal en la solicitud
                        auxAniAnterior = o.GetIdAnimal(auxSolic.IdAnimal);

                        //Si el IdAnimal actual es diferente al Id del animal seleccionado anteriormente
                        //entonces cambiará el estado del animal anterior a "Disponible"

                        if (int.Parse(txtIdAnimal.Text) != auxAniAnterior.IdAnimal)
                        {
                            auxAniAnterior.EstadoAnimal = "Disponible";
                            o.UpdateAnimal(auxAniAnterior);
                        }

                        if (cmbEstado.Text == "En proceso")
                        {
                            auxAni.EstadoAnimal = "No disponible";

                        }
                        else if (cmbEstado.Text == "Aprobada")
                        {
                            auxAni.EstadoAnimal = "Adoptado";
                        }
                        else if (cmbEstado.Text == "Anulada" || cmbEstado.Text == "Rechazada")
                        {
                            auxAni.EstadoAnimal = "Disponible";
                        }

                        //Actualizar animal tanto el actual como el anterior
                        o.UpdateAnimal(auxAni);

                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else

                    MessageBox.Show("Ingrese correctamente los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }
        private void frmEditSolicitud_Load(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {
            frmAdminAdoptante frm = new frmAdminAdoptante();
            frm.btnNuevo.Enabled = false;
            frm.btnEditar.Enabled = false;
            frm.btnEliminar.Enabled = false;
            frm.btnSeleccionar.Enabled = true;
            frm.btnVer.Visible = false;
            frm.btnSeleccionar.Visible = true;
            frm.ListarAdoptantes();
            frm.ShowDialog();
        }
    }
}
