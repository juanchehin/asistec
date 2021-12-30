using educatec.CapaLogica;
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
    public partial class formAsistencias : Form
    {
        LAsistencias objetoCL = new LAsistencias();
        private DateTime Fecha = DateTime.Today; // Fecha actual

        public formAsistencias()
        {
            InitializeComponent();
            ListarAsistencias(DateTime.Today);
            this.Fecha = dtpFecha.Value;
            ListarAsistencias(this.Fecha);
        }

        public void ListarAsistencias(DateTime Fecha)
        {
            dataListadoAsistencias.DataSource = objetoCL.ListarAsistencias(dtpFecha.Value.Date);
            dataListadoAsistencias.Columns[0].Visible = false;
            lblTotalAsistencias.Text = Convert.ToString(dataListadoAsistencias.Rows.Count);
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("dtpFecha.Value.Date " + dtpFecha.Value.Date);
            ListarAsistencias(dtpFecha.Value.Date);
        }
    }
}