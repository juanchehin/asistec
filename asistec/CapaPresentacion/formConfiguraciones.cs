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
    public partial class formConfiguraciones : Form
    {
        public formConfiguraciones()
        {
            InitializeComponent();
        }

        private void btnIP_Click(object sender, EventArgs e)
        {
            formIP frm = new formIP();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnBackEnd_Click(object sender, EventArgs e)
        {
            formCargando frm = new formCargando();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
