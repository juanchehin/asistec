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
        public formAsistencias()
        {
            InitializeComponent();
            ListarAsistencias();
        }

        public void ListarAsistencias()
        {
            // Message.Show("Educatec" + dtpFecha);
            // Console.WriteLine("dtpFecha en capa negocio es : " + dtpFecha.Value.Date);

            dataListadoAsistencias.DataSource = objetoCL.ListarAsistencias(dtpFecha.Value.Date);
            dataListadoAsistencias.Columns[0].Visible = false;
            lblTotalAsistencias.Text = Convert.ToString(dataListadoAsistencias.Rows.Count);
        }
    }
}