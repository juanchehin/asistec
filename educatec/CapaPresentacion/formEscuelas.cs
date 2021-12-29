using educatec.CapaLogica;
using educatec.CapaPresentacion;
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
    public partial class formEscuelas : Form
    {
        LEscuelas objetoCN = new LEscuelas();
        public formEscuelas()
        {
            InitializeComponent();
            ListarEscuelas();
        }

        public void ListarEscuelas()
        {
            // Console.WriteLine("Ahora va el mostrar productos");
            dataListadoEscuelas.DataSource = objetoCN.ListarEscuelas();
            dataListadoEscuelas.Columns[0].Visible = false;
            lblTotalEscuelas.Text = Convert.ToString(dataListadoEscuelas.Rows.Count);
            // this.banderaFormularioHijo = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ListarEscuelas();
        }

        private void btnAgregarEscuela_Click(object sender, EventArgs e)
        {
            formNuevaEditarEscuela frm = new formNuevaEditarEscuela();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}
