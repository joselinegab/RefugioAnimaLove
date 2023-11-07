using CapaEntidades;
using CapaEntidades.Clases_personalizadas;
using CapaLogica.Clases_personalizadas;
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
    public partial class frmAdminTratamientoAnimal : Form
    {
        public frmAdminTratamientoAnimal()
        {
            InitializeComponent();
        }
        TratamientoAnimalLN opln = new TratamientoAnimalLN();
        AnimalTratamientoLN oplnn = new AnimalTratamientoLN();
        AnimalLN ani = new AnimalLN();

        //MÉTODOS PARA LISTAR: LISTAR TODO Y LISTAR POR INGRESO
        public void ListarTratamientoAnimalsFiltro(string dato)
        {
            dtgDatos.DataSource = oplnn.ViewAnimalTratamientoFiltro(dato);
        }

        public void MostrarCMB()
        {
            cmbFiltro.DataSource = ani.ViewAnimalFiltro("");
            cmbFiltro.DisplayMember = "Nombre";
            cmbFiltro.ValueMember = "IdAnimal";

        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void frmAdminTratamientoAnimal_Load(object sender, EventArgs e)
        {
            MostrarCMB();
           if(cmbFiltro.Text == "Todos")
            {
                ListarTratamientoAnimalsFiltro("");
            }
            else
            {
                ListarTratamientoAnimalsFiltro(cmbFiltro.Text);

            }



        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.Text == "Todos")
            {
                ListarTratamientoAnimalsFiltro("");
            }
            else
            {
                ListarTratamientoAnimalsFiltro(cmbFiltro.Text);

            }


        }
    }
}
