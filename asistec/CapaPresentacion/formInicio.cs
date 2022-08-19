using asistec.CapaPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asistec.CapaPresentacion
{
    public partial class formInicio : Form
    {
        public formInicio()
        {
            InitializeComponent();
        }

        private void btnNuevaAsistencia_Click(object sender, EventArgs e)
        {
            formAsistencia frm = new formAsistencia();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnAsistencias_Click(object sender, EventArgs e)
        {
            formAsistencias frm = new formAsistencias();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnAgregarPersonal_Click(object sender, EventArgs e)
        {
            formNuevoEditarPersonal frm = new formNuevoEditarPersonal();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnListarPersonal_Click(object sender, EventArgs e)
        {
            formPersonal frm = new formPersonal();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            formAcercaDe frm = new formAcercaDe();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnAgregarEscuela_Click(object sender, EventArgs e)
        {
            formNuevaEditarEscuela frm = new formNuevaEditarEscuela();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnListarEscuelas_Click(object sender, EventArgs e)
        {
            formEscuelas frm = new formEscuelas();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnConfiguraciones_Click(object sender, EventArgs e)
        {
            formConfiguraciones frm = new formConfiguraciones();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void formInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
