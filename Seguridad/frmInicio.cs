using CapaDatos.CD;
using CapaDatos.Refugio;
using RefugioAnimaLove.Admin;
using RefugioAnimaLove.Personalizadas;
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

namespace RefugioAnimaLove.Seguridad
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
            Size = new Size(920, 580);
            this.CenterToScreen();
            //Form2 form = new Form2();
            //form.Size = new Size(250, 200);
            //form.Show();
            lbAni.Text = ContarAnimales().ToString();
            lbAdop.Text = ContarAdoptantes().ToString();
            lbSoli.Text = ContarSolicitudes().ToString();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void CerrarForms()
        {
            foreach (var item in this.MdiChildren)
                item.Dispose();
        }
        public static int ContarAnimales()
        {
            var sql = from le in AnimalCD.ListarAnimal()
                      group le by le.IdAnimal into l
                      select new { l.Key, a = l.Count() };
            return sql.ToList().Count();
        }
        public static int ContarSolicitudes()
        {
            var sql = from le in SolicitudCD.ListarSolicitud()
                      group le by le.IdSolicitud into l
                      select new { l.Key, a = l.Count() };
            return sql.ToList().Count();
        }
        public static int ContarAdoptantes()
        {
            var sql = from le in AdoptanteCD.ListarAdoptante()
                      group le by le.IdAdoptante into l
                      select new { l.Key, a = l.Count() };
            return sql.ToList().Count();
        }
        private void frmInicio_Load(object sender, EventArgs e)
        {
            lbAni.Text = ContarAnimales().ToString();
            lbAdop.Text = ContarAdoptantes().ToString();
            lbSoli.Text = ContarSolicitudes().ToString();
        }

        private void usuariostm_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminUsuario());

        }

     

        private void adoptantestm_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminAdoptante());

        }

        private void candidatostm_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminAnimal());

        }

        private void solicitudestm_Click(object sender, EventArgs e)
        {

        }

        private void tratamientostm_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminTratamiento());

        }

        private void administrarPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminPersonal());

        }

        private void tiposDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminTipoPersonal());

        }

        private void especiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminEspecie());

        }

        private void administrarSolicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminSolicitudAdopcion());

        }

        private void estadosDeSolicitudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminEstadoSolicitud());

        }

        private void animalestm_Click(object sender, EventArgs e)
        {

        }

        private void administrarEstadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminEstadoAnimal());

        }

        private void enTratamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminTratamientoAnimal());

        }

        private void animalesEnTratamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminAnimalTratamiento());

        }

        private void administrarAnimalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminAnimal());
            

        }


        private void listaDeAnimalesEnTratamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminTratamientoAnimal());

        }

        private void generarReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCRSolicitud());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new frmAdminUsuario());

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openChildForm(new frmAdminTratamientoAnimal());

        }
        private void usuariostm_MouseEnter(object sender, EventArgs e)
        {
        }

        private void usuariostm_MouseLeave(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
