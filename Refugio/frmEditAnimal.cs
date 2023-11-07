using CapaEntidades;
using CapaLogica.Refugio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefugioAnimaLove.Refugio
{
    public partial class frmEditAnimal : Form
    {
        public frmEditAnimal()
        {
            InitializeComponent();
            Size = new Size(588, 600);
            this.CenterToScreen();

        }
        AnimalLN opl = new AnimalLN();
        EspecieLN epl = new EspecieLN();
        EstadoAnimalLN eanln = new EstadoAnimalLN();
        public bool banActualizar;
        public bool val;

        public void MostrarCMB()
        {
            cmbEstadoAnimal.DataSource = eanln.ViewEstadoAnimal();
            cmbEstadoAnimal.DisplayMember = "Estado";
            cmbEstadoAnimal.ValueMember = "Estado";

            cmbEspecie.DataSource = epl.ViewEspecie();
            cmbEspecie.DisplayMember = "Nombre";
            cmbEspecie.ValueMember = "Nombre";

            //textBox6.Text = aux.ViewAerolineas(comboBox1.Text).ToString();
        }
        public bool existeCodigo(int cod)
        {
            Animal op = opl.GetIdAnimal(cod);
            if (op != null)
            {
                MessageBox.Show($"El código {cod} ya existe", "Código repetido");
                return false;
            }
            else
                return true;
        }
        private byte[] GetBytes(Image imageIN)
        {
            MemoryStream ms = new MemoryStream();
            imageIN.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }
        public Animal CrearObjeto()
        {
            int id = int.Parse(txtCod.Text);
            string nom = txtNombre.Text;
            char sexo = ' ';
            if (rbH.Checked == true)
            {
                sexo = 'H';
            }
            else if (rbMM.Checked == true)
            {
                sexo = 'M';
            }
            string edad = txtEdad.Text;
            string peso = txtPeso.Text;
            string tam = cmTamanio.Text;
            string enfer="";
            if (rbsienfermo.Checked == true)
            {
                enfer = "SI";
            }
            else if (rbnoenfermo.Checked == true)
            {
                enfer ="NO";
            }
            string ester="";
            if (rbsiester.Checked == true)
            {
                ester = "SI";
            }
            else if (rbnoester.Checked == true)
            {
                ester = "NO";
            }
            string enfermedad = txtEnfermedad.Text;
            string vacu = txtVacunas.Text;
            DateTime fNac = dtNaci.Value.Date;
            DateTime fLlega = dtLlega.Value.Date;

            byte[] foto = GetBytes(ptbImagen.Image);

            string esp = cmbEspecie.Text;
            string estado = cmbEstadoAnimal.Text;


            return new Animal(id,nom,sexo,fNac,edad,tam,peso,enfer,ester,enfermedad,vacu,fLlega,foto,esp,estado);
        }
        public void CargarDatos(Animal op)
        {
            txtCod.Text = op.IdAnimal.ToString();
            txtNombre.Text = op.Nombre;
            if (op.Sexo == 'H')
                rbH.Checked = true;
            if (op.Sexo == 'M')
                rbMM.Checked = true;
            txtEdad.Text=op.Edad.ToString();
            txtPeso.Text=op.Peso;
            cmTamanio.Text=op.Tamanio;
            if (op.Enfermo == "SI")
                rbsienfermo.Checked = true;
            if (op.Enfermo == "NO")
                rbnoenfermo.Checked = true;
            if (op.Esterilizado == "SI")
                rbsiester.Checked = true;
            if (op.Esterilizado == "NO")
                rbnoester.Checked = true;
            txtEnfermedad.Text = op.Enfermedad;
            txtVacunas.Text = op.Vacunas;
            dtNaci.Value = op.FechaNacimiento.Date;
            dtLlega.Value = op.FechaLlegada.Date;
            cmbEspecie.Text = op.Especie;
            cmbEstadoAnimal.Text = op.EstadoAnimal;

            byte[] imagen = op.Foto;
            MemoryStream ms = new MemoryStream(imagen);
            ptbImagen.Image = Image.FromStream(ms);
            ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            MostrarCMB();

        }
        public bool validarEntradas()
        {
            int cod = int.Parse(txtCod.Text);
            if (banActualizar == false)
            {
                val = existeCodigo(cod);
            }
            if (txtCod.Text.Trim().Length == 0 || txtNombre.Text.Trim().Length == 0 ||
                txtPeso.Text.Trim().Length == 0 ||
                txtEdad.Text.Trim().Length == 0)
            {
                val = false;
            }
            return val;
        }


        public void Guardar()
        {
            try
            {
                if (validarEntradas()) 
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Ingrese correctamente los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void frmEditAnimal_Load(object sender, EventArgs e)
        {
            MostrarCMB();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
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

        private void dtNaci_ValueChanged(object sender, EventArgs e)
        {
            DateTime today;
            today = DateTime.Now;
            string edad;

            int años = today.Year - dtNaci.Value.Year;
            if (today.Month < dtNaci.Value.Month || (today.Month == dtNaci.Value.Month &&
            today.Day < dtNaci.Value.Day))
                años--;

            int meses = today.Month - dtNaci.Value.Month;
            if (today.Day < dtNaci.Value.Day)
                meses--;
            if (meses < 0)
                meses += 12;

            int dias = today.Day - dtNaci.Value.Day;

            if(años == 0)
            {
                edad = meses + " meses";
            }else
                edad = años.ToString() + " año/s y " + meses + " meses";
            if(meses==0 && años == 0)
            {
                edad= dias+ " días";
            }
            if (meses == 0)
            {
                edad = años.ToString() + " año/s";
            }
            if (años < 0 || meses < 0)
            {
                MessageBox.Show("Dato no válido.\nPor favor cambie la fecha de nacimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                val = false;
            }
            else
            {
                val = true;
                txtEdad.Text = edad;
            }  
        }

        private void cmbEstadoAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ptbImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.Title = "Seleccionar imagen";
            Dialog.Filter = "Archivos de imagen (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            DialogResult Resultado = Dialog.ShowDialog();

            if (Resultado == DialogResult.OK)
            {
                ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                ptbImagen.Image = Image.FromFile(Dialog.FileName);
            }
            else
            {
                MessageBox.Show("No se seleccionó ninguna imagen", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
