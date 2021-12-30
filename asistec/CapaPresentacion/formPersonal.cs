using asistec.CapaLogica;
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
        LPersonal objetoCL = new LPersonal();
        public formPersonal()
        {
            InitializeComponent();
            ListarPersonal();
        }

        private void btnNuevoPersonal_Click(object sender, EventArgs e)
        {
            formNuevoEditarPersonal frm = new formNuevoEditarPersonal();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        public void ListarPersonal()
        {
            dataListadoPersonal.DataSource = objetoCL.ListarPersonal();
            dataListadoPersonal.Columns[0].Visible = false;
            lblTotalPersonal.Text = Convert.ToString(dataListadoPersonal.Rows.Count);
        }
    }
}
