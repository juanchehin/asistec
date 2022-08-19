using asistec.CapaLogica;
using SpreadsheetLight;
using System;
using System.Data;
using System.Windows.Forms;

namespace asistec.CapaPresentacion
{
    public partial class formAsistencias : Form
    {
        LAsistencias objetoCL = new LAsistencias();
        private DateTime Fecha = DateTime.Today; // Fecha actual
        int desde = 0;
        string totalAsistencias;
        DataSet ds = new DataSet();

        public formAsistencias()
        {
            InitializeComponent();
            ListarAsistencias(0);
            this.Fecha = dtpFecha.Value;
            ListarAsistencias(0);
        }

        public void ListarAsistencias(int pDesde)
        {
            try
            {
                ds = objetoCL.ListarAsistencias(dtpFecha.Value.Date, pDesde);
                dataListadoAsistencias.DataSource = ds.Tables[0];
                totalAsistencias = ds.Tables[1].Rows[0][0].ToString();
                lblTotalAsistencias.Text = totalAsistencias;
            }
            catch
            {
                //ds = objetoCL.ListarAsistencias(dtpFecha.Value.Date, pDesde);
                //dataListadoAsistencias.DataSource = ds.Tables[0];
                totalAsistencias = "0";
                lblTotalAsistencias.Text = totalAsistencias;
            }
            
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            ListarAsistencias(this.desde);
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
            sl.SetCellValue(1, 7, "HorasTrabajadas");

            sl.SetCellStyle(1,1,style);
            sl.SetCellStyle(1, 2, style);
            sl.SetCellStyle(1, 3, style);
            sl.SetCellStyle(1, 4, style);
            sl.SetCellStyle(1, 5, style);
            sl.SetCellStyle(1, 6, style);
            sl.SetCellStyle(1, 7, style);

            int fila = 0;

            for(int i = 2; i < (dataListadoAsistencias.Rows.Count + 2 ); i++ )
            {
                sl.SetCellValue(i, 1, dataListadoAsistencias.Rows[fila].Cells["DNI"].Value.ToString());
                sl.SetCellValue(i, 2, dataListadoAsistencias.Rows[fila].Cells["Apellidos"].Value.ToString());
                sl.SetCellValue(i, 3, dataListadoAsistencias.Rows[fila].Cells["Nombres"].Value.ToString());
                sl.SetCellValue(i, 4, dataListadoAsistencias.Rows[fila].Cells["Escuela"].Value.ToString());
                sl.SetCellValue(i, 5, dataListadoAsistencias.Rows[fila].Cells["HorarioEntrada"].Value.ToString());
                sl.SetCellValue(i, 6, dataListadoAsistencias.Rows[fila].Cells["HorarioSalida"].Value.ToString());
                sl.SetCellValue(i, 7, dataListadoAsistencias.Rows[fila].Cells["HorasTrabajadas"].Value.ToString());

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

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            if (desde >= Convert.ToInt32(totalAsistencias))
            {
                return;
            }

            if (desde < 0)
            {
                this.desde = 0;
                return;
            }

            this.desde += 15;
            this.ListarAsistencias(this.desde);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.desde -= 15;
            if (desde <= 0)
            {
                this.desde = 0;
            }
            
            this.ListarAsistencias( this.desde);
        }
    }
}