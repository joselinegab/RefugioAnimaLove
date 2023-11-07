using CapaEntidades;
using CapaLogica.Refugio;
using RefugioAnimaLove.Personalizadas;
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
    public partial class frmAdminAnimal : Form
    {
        public frmAdminAnimal()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        AnimalLN opln = new AnimalLN(); 

        public void ListarAnimalsFiltro(string dato)
        {
            dtgDatos.DataSource = opln.ViewAnimalFiltro(dato);
        }

        public void ListarAnimals()
        {
            dtgDatos.DataSource = opln.ViewAnimal();
        }
      
        public void Nuevo()
        {
            try
            {
                frmEditAnimal frm = new frmEditAnimal();
                frm.Text = "Registrar animal";
                frm.label3.Text = "Registrar animal";
                frm.banActualizar = false;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Animal op = frm.CrearObjeto();
                    opln.CreateAnimal(op);
                    frm.Close();
                    tEstado.Text = "Animal ingresado";
                }
                else
                {
                    tEstado.Text = "Ingreso cancelado";
                }
                ListarAnimals();
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al ingresar Animal";
            }
        }

        //MÉTODO PARA MODIFICAR UN DATO ESPECÍFICO SEGÚN SU ID
        public void Modificar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    frmEditAnimal frm = new frmEditAnimal();
                    frm.Text = "Actualizar animal";
                    frm.label3.Text = "Actualizar datos del animal";
                    frm.banActualizar = true;
                    frm.txtCod.Enabled = false;

                    Animal op = null;

                    op = dtgDatos.CurrentRow.DataBoundItem as Animal;

                    frm.CargarDatos(op);
                    frm.ShowDialog(this);

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        op = frm.CrearObjeto();
                        opln.UpdateAnimal(op);
                        frm.Close();
                        tEstado.Text = "Datos del animal actualizados";
                       
                    }
                    else
                    {
                        tEstado.Text = "Actualización cancelada";
                    }
                    ListarAnimals();
                }
                else
                {
                    tEstado.Text = "Seleccione un animal";
                }
            }
            catch (Exception ex)
            {
                tEstado.Text = "Error al actualizar datos del animal";
            }
        }

        //MÉTODO PARA ELIMINAR UN DATO SELECCIONADO SEGÚN SU ID
        public void Eliminar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar el animal seleccionado?", "Eliminar animal", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Animal op = dtgDatos.CurrentRow.DataBoundItem as Animal;
                        opln.DeleteAnimal(op);
                        ListarAnimals();
                        tEstado.Text = "Animal eliminado";
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
                tEstado.Text = "Error al eliminar Animal";
            }
        }
        public void Seleccionar()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    var res = MessageBox.Show("Desea seleccionar este Animal?", "Seleccionar Animal", MessageBoxButtons.YesNo);
                    if (res.ToString().Equals("Yes"))
                    {
                        string estado = dtgDatos.CurrentRow.Cells[14].Value.ToString();
                        if (estado == "Disponible"|| estado =="En tratamiento")
                        {
                            string idani = dtgDatos.CurrentRow.Cells[0].Value.ToString();
                            string nani = dtgDatos.CurrentRow.Cells[1].Value.ToString();
                            char sexo = (char)dtgDatos.CurrentRow.Cells[2].Value;
                            string edad = dtgDatos.CurrentRow.Cells[4].Value.ToString();
                            string peso = dtgDatos.CurrentRow.Cells[6].Value.ToString();
                            string enf = dtgDatos.CurrentRow.Cells[7].Value.ToString();
                            string ester = dtgDatos.CurrentRow.Cells[8].Value.ToString();
                            string enfermedad = dtgDatos.CurrentRow.Cells[9].Value.ToString();
                            string vacus = dtgDatos.CurrentRow.Cells[10].Value.ToString();
                            byte[] foto = (byte[])dtgDatos.CurrentRow.Cells[12].Value;
                            frmEditSolicitud g = Application.OpenForms["frmEditSolicitud"] as frmEditSolicitud;
                            g.txtIdAnimal.Text = idani;
                            g.txtNombre.Text = nani;
                            g.txtEdad.Text = edad;
                            g.txtPeso.Text = peso;
                            if (sexo == 'H')
                                g.rbH.Checked = true;
                            if (sexo == 'M')
                                g.rbMM.Checked = true;

                            if (enf == "SI")
                                g.rbsienfermo.Checked = true;
                            if (enf == "NO")
                                g.rbnoenfermo.Checked = true;

                            if (ester == "SI")
                                g.rbsiester.Checked = true;
                            if (ester == "NO")
                                g.rbnoester.Checked = true;

                            g.txtEnfermedad.Text = enfermedad;
                            g.txtVacus.Text = vacus;
                            MemoryStream ms = new MemoryStream(foto);
                            g.ptbImagen.Image = Image.FromStream(ms);
                            g.ptbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                            //g.txtEdad.Text = edad;
                            //g.cmbEspecie.Text = esp;
                            //tEstado.Text = "Datos ingresados correctamente";
                            this.Close();
                        }else
                        {
                            MessageBox.Show("Este animal no está disponible para adopción.\nPor favor seleccione otro o cambie su estado","Error al seleccionar animal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                       
                    }
                    else
                        tEstado.Text = " Selección cancelada";
                }
                else
                    MessageBox.Show(this, "Seleccione la fila");
            }
            catch (Exception ex)
            {
                tEstado.Text = " Error al seleccionar animal";
            }
        }
        public void AsignarTratamiento()
        {
            try
            {
                if (dtgDatos.CurrentRow != null)
                {
                    string enfermo = dtgDatos.CurrentRow.Cells[7].Value.ToString();
                    if (enfermo == "SI")
                    {
                        frmAdminAnimalTratamiento frm = new frmAdminAnimalTratamiento();
                        frm.aux = dtgDatos.CurrentRow.DataBoundItem as Animal;
                        frm.opp = 1;
                        frm.ShowDialog();

                        if (frm.DialogResult == DialogResult.OK)
                        {
                            frm.Close();
                            tEstado.Text = "Tratamiento ingresado";
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Sólo los animales en los que su ficha indica que están enfermos pueden recibir un tratamiento.\n" +
                        "Por favor actualice sus datos o seleccione otro.","No se ha podido seleccionar este animal", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }

            }
            catch (Exception ex)
            {
                tEstado.Text = ex.Message;
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ListarAnimalsFiltro(txtBuscar.Text);

        }

        private void frmAdminAnimal_Load(object sender, EventArgs e)
        {
            ListarAnimalsFiltro("");
            mostrarfiltro();

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
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
        public void mostrarfiltro()
        {
            if (comboBox1.Text == "Todos")
            {
                ListarAnimals();

            }
            if (comboBox1.Text == "Disponible")
            {
                ListarAnimalsFiltro(comboBox1.Text);
            }
            if (comboBox1.Text == "No disponible")
            {
                ListarAnimalsFiltro(comboBox1.Text);
            }
            if (comboBox1.Text == "En tratamiento")
            {
                ListarAnimalsFiltro(comboBox1.Text);
            }
            if (comboBox1.Text == "Adoptado")
            {
                ListarAnimalsFiltro(comboBox1.Text);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarfiltro();

        }

        private void btnAggTrata_Click(object sender, EventArgs e)
        {
            AsignarTratamiento();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
