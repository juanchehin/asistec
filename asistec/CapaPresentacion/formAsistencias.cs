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
            SLDocument s1 = new SLDocument();
            SLStyle style = new SLStyle();
            style.Font.FontSize = 12;
            style.Font.Bold = true;

            s1.SetCellValue(1, 1, "DNI");
            s1.SetCellValue(1, 2, "Apellidos");
            s1.SetCellValue(1, 3, "Nombres");
            s1.SetCellValue(1, 4, "Escuela");
            s1.SetCellValue(1, 5, "HorarioEntrada");
            s1.SetCellValue(1, 6, "HorarioSalida");

            s1.SetCellStyle(1,1,style);
            s1.SetCellStyle(1, 2, style);
            s1.SetCellStyle(1, 3, style);
            s1.SetCellStyle(1, 4, style);
            s1.SetCellStyle(1, 5, style);
            s1.SetCellStyle(1, 6, style);

            int fila = 1;
            int columna = 0;
            // int totalFilas = dataListadoAsistencias.Rows.Count;

            for(int i = 0; i < dataListadoAsistencias.Rows.Count; i++ )
            {

                // s1.SetCellValue(i, 0, dataListadoAsistencias.Cells[fila].Value.ToString());
                s1.SetCellValue(i, 1, dataListadoAsistencias.Rows[i].Cells[1].Value.ToString());
                s1.SetCellValue(i, 2, dataListadoAsistencias.Rows[i].Cells[2].Value.ToString());
                s1.SetCellValue(i, 3, dataListadoAsistencias.Rows[i].Cells[3].Value.ToString());
                s1.SetCellValue(i, 4, dataListadoAsistencias.Rows[i].Cells[4].Value.ToString());
                s1.SetCellValue(i, 5, dataListadoAsistencias.Rows[i].Cells[5].Value.ToString());
                // s1.SetCellValue(i, 5, dataListadoAsistencias.Rows[i].Cells[6].Value.ToString());
                Console.WriteLine(" Rows[i].Cells[1] " + dataListadoAsistencias.Rows[i].Cells[1].Value.ToString());
                Console.WriteLine(" -- Salto -- " + i);

                /*foreach (DataGridViewRow row in dataListadoAsistencias.Rows)
                {
                    Console.WriteLine("Ahora va el cell : " + row.Cells[fila].Value.ToString());
                    
                    s1.SetCellValue(fila, columna, row.Cells[fila].Value.ToString());
                    columna++;
                }
                Console.WriteLine(" -- Salto -- ");
                fila++;*/
            }

            // int iC = 1;
            // int iR = 1;

            /*foreach (DataGridViewColumn column in dataListadoAsistencias.Columns)
            {
                s1.SetCellValue(1, iC, column.HeaderText.ToString());
                s1.SetCellValue(1, 2, "columna 2");
                s1.SetCellStyle(1, iC,style);                
            }*/



            s1.SaveAs("C:/Users/Chehin/Documents/asistencias.xlsx");
        }
    }
}