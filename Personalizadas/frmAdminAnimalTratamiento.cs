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

namespace RefugioAnimaLove.Personalizadas
{
    public partial class frmAdminAnimalTratamiento : Form
    {
        public frmAdminAnimalTratamiento()
        {
            InitializeComponent();
            this.CenterToScreen();
            //ancho,alto
            Size = new Size(692, 580);
        }
        AnimalTratamientoLN opln = new AnimalTratamientoLN();
        TratamientoAnimalLN oplnn = new TratamientoAnimalLN();
        AnimalLN an = new AnimalLN();

        TratamientoLN op = new TratamientoLN();
        public Animal aux;

        public int opp;
        public bool banActualizar;


        //MÉTODOS PARA LISTAR: LISTAR TODO Y LISTAR POR INGRESO
        public void ListarAnimalTratamientosFiltro(string dato)
        {
            dtgDatos.DataSource = opln.ViewAnimalTratamientoFiltro(dato);
        }
        public bool existeCodigo(string cod)
        {
            TratamientoAnimal op = oplnn.GetIdTratamientoAnimal(cod);
            if (op != null)
            {
                MessageBox.Show($"El código {cod} ya existe", "Código repetido");
                return false;
            }
            else
                return true;
        }

        public void ListarAnimalTratamientos()
        {
            dtgDatos.DataSource = opln.ViewAnimalTratamiento();
        }
        public void ListarATXIdAnimal(int val)
        {
            dtgDatos.DataSource = opln.ViewAT_FiltroXIdAnimal(val.ToString());
        }
        private void frmAdminAnimalTratamiento_Load(object sender, EventArgs e)
        {
            MostrarCMB();
            MostrarDatosAnimal();
            ListarATXIdAnimal(aux.IdAnimal);


        }

        public TratamientoAnimal CrearObjeto()
        {
            string idTrat = txtId.Text;
            string cau = txtCausa.Text;
            DateTime f = dtFecha.Value.Date;
            string com = txtComen.Text;
            string trata = cmbTratamiento.Text;
            int idAni = int.Parse(txtCod.Text);
            return new TratamientoAnimal(idTrat, cau, f, com, trata, idAni);

        }
        public void Limpiar()
        {
            txtId.Clear();
            txtComen.Clear();
            txtCausa.Clear();

            cmbTratamiento.SelectedIndex = 0;

        }
        public void MostrarCMB()
        {
            cmbTratamiento.DataSource = op.ViewTratamiento();
            cmbTratamiento.DisplayMember = "Nombre";
            cmbTratamiento.ValueMember = "Nombre";
        }
        public void MostrarDatosAnimal()
        {
            txtCod.Text = aux.IdAnimal.ToString();
            txtPeso.Text = aux.Peso;
            txtNom.Text = aux.Nombre;
            txtEdad.Text = aux.Edad;
            if (aux.Sexo == 'H')
                rbH.Checked = true;

            if (aux.Sexo == 'M')

                rbM.Checked = true;



            txtCausa.Text = aux.Enfermedad;

            byte[] imagen = aux.Foto;
            MemoryStream ms = new MemoryStream(imagen);
            ptbImagen.Image = Image.FromStream(ms);
            ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            if (aux.Esterilizado == "SI")
                rbSi.Checked = true;
            if (aux.Esterilizado == "NO")
                rbNo.Checked = true;

        }
        public bool ValidarDatos()
        {
            bool Verificar = true;
            string cod = txtCod.Text;
            if (banActualizar == false)
            {
                Verificar = existeCodigo(cod);
            }
            if (txtId.Text.Trim().Length == 0 || txtCausa.Text.Trim().Length == 0)
            {
                Verificar = false;
            }
            return Verificar;
        }
        public void Guardar()
        {
            try
            {
                if (ValidarDatos())
                {
                    
                    TratamientoAnimal pt = CrearObjeto();
                    if (opp == 1)
                    {
                        oplnn.CreateTratamientoAnimal(pt);
                        aux.EstadoAnimal = "En tratamiento";
                        an.UpdateAnimal(aux);
                        tEstado.Text = "Ingreso exitoso";
                        Limpiar();



                    }
                    else
                    {
                        oplnn.UpdateTratamientoAnimal(pt);
                        tEstado.Text = "Actualización exitosa";

                    }
                    ListarATXIdAnimal(aux.IdAnimal);
                    
                }
                else

                    MessageBox.Show("Ingrese correctamente los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void Eliminar()
        {

            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("Está seguro que desea eliminar el tratamiento seleccionado?", "Eliminar Tratamiento del Animal", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AnimalTratamiento op = dtgDatos.CurrentRow.DataBoundItem as AnimalTratamiento;
                        oplnn.DeleteTratamientoAnimalXIdAnimal(op.IdAnimal);
                        ListarATXIdAnimal(aux.IdAnimal);
                        if (dtgDatos == null)
                        {
                            aux.EstadoAnimal = "Disponible";
                            an.UpdateAnimal(aux);
                        }
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
                tEstado.Text = "Error al eliminar la fila seleccionada";
            }
        }
        public void SetDatos(AnimalTratamiento pt)
        {
            txtId.Text = pt.IdTratamientoAnimal.ToString();
            txtCausa.Text = pt.Causa;
            txtComen.Text = pt.Comentario;
            dtFecha.Value = pt.Fecha.Date;
            cmbTratamiento.Text = pt.Tratamiento;

            //Datos del animal
            txtCod.Text = pt.IdAnimal.ToString();
            txtNom.Text = aux.Nombre;
            txtPeso.Text = aux.Peso;
            txtEdad.Text = aux.Edad;

            if (aux.Sexo == 'H')
                rbH.Checked = true;
            if (aux.Sexo == 'M')
                rbM.Checked = true;
            if (aux.Esterilizado == "SI")
                rbSi.Checked = true;
            if (aux.Esterilizado == "NO")
                rbNo.Checked = true;

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId.Enabled = true;
            opp = 1;
            banActualizar = false;
            Limpiar();
            btnGuardar.Enabled = false;
        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            opp = 2;
            banActualizar = true;
            txtId.Enabled = false;
            if (dtgDatos.CurrentRow != null)
            {
                AnimalTratamiento ptt = null;

                ptt = dtgDatos.CurrentRow.DataBoundItem as AnimalTratamiento;
                //int id = ptt.IdReserva;
                SetDatos(ptt);
            }
            else
            {
                MessageBox.Show("No existen datos");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
