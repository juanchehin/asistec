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
    public partial class formPersonal : Form
    {
        public formPersonal()
        {
            InitializeComponent();
        }

        private void btnNuevoPersonal_Click(object sender, EventArgs e)
        {
            formNuevoEditarPersonal frm = new formNuevoEditarPersonal();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
