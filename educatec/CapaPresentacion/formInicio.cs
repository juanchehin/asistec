using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace educatec.CapaPresentacion
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
    }
}
