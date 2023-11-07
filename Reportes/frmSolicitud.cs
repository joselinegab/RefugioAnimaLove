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

namespace RefugioAnimaLove.Reportes
{
    public partial class frmSolicitud : Form
    {
        public frmSolicitud()
        {
            InitializeComponent();
        }
        
        SolicitudAdopcionLN oln = new SolicitudAdopcionLN();
        DSSolicitud ds = new DSSolicitud();
        public Animal a;
        //AnimalLN op = new AnimalLN();
        public void MostrarReporte()
        {
            try
            {
                List<SolicitudAdopcion> lista = oln.ViewSolicitudAdopcionFiltro(a.IdAnimal.ToString());
                foreach (SolicitudAdopcion op in lista)
                {
                    ds.v_SolicitudAdopcion.Addv_SolicitudAdopcionRow(op.IdSolicitud, op.Fecha, op.Estado, op.Nombre, op.Sexo.ToString(), op.Edad, op.Peso, op.Enfermo, op.Esterilizado, op.Enfermedad,
                        op.Vacunas, op.Foto, op.Identificacion, op.Nombres, op.Apellidos, op.EdadAdop, op.Ciudad, op.Direccion, op.Celular, op.Email, op.IdAdoptante, op.IdAnimal.ToString());
                }
                CRGenerarSolicitud rp = new CRGenerarSolicitud();
                rp.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rp;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmSolicitud_Load(object sender, EventArgs e)
        {
            MostrarReporte();
        }
    }
}
