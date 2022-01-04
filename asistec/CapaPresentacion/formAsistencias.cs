using educatec.CapaLogica;
using SpreadsheetLight;
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
            ListarAsistencias(dtpFecha.Value.Date);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SLDocument sl = new SLDocument();
            SLStyle style = new SLStyle();
            style.Font.FontSize = 12;
            style.Font.Bold = true;

            sl.SetCellValue(1, 1, "DNI");
            sl.SetCellValue(1, 2, "Apellidos");
            sl.SetCellValue(1, 3, "Nombres");
            sl.SetCellValue(1, 4, "Escuela");
            sl.SetCellValue(1, 5, "HorarioEntrada");
            sl.SetCellValue(1, 6, "HorarioSalida");

            sl.SetCellStyle(1,1,style);
            sl.SetCellStyle(1, 2, style);
            sl.SetCellStyle(1, 3, style);
            sl.SetCellStyle(1, 4, style);
            sl.SetCellStyle(1, 5, style);
            sl.SetCellStyle(1, 6, style);

            int fila = 0;

            for(int i = 2; i < (dataListadoAsistencias.Rows.Count + 2 ); i++ )
            {
                sl.SetCellValue(i, 1, dataListadoAsistencias.Rows[fila].Cells["DNI"].Value.ToString());
                sl.SetCellValue(i, 2, dataListadoAsistencias.Rows[fila].Cells["Apellidos"].Value.ToString());
                sl.SetCellValue(i, 3, dataListadoAsistencias.Rows[fila].Cells["Nombres"].Value.ToString());
                sl.SetCellValue(i, 4, dataListadoAsistencias.Rows[fila].Cells["Escuela"].Value.ToString());
                sl.SetCellValue(i, 5, dataListadoAsistencias.Rows[fila].Cells["HorarioEntrada"].Value.ToString());
                sl.SetCellValue(i, 6, dataListadoAsistencias.Rows[fila].Cells["HorarioSalida"].Value.ToString());

                fila++;
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Guardar archivo";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sl.SaveAs(saveFileDialog1.FileName);
                    MessageBox.Show("Archivo exportado con éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}