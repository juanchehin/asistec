using asistec.CapaLogica;
using asistec.CapaDatos;
using asistec.CapaLogica;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asistec.CapaPresentacion
{
    public partial class formNuevoEditarPersonal : Form
    {
        LPersonal objetoCN = new LPersonal();
        LEscuelas objetoCL_asistencia = new LEscuelas();
        private DataTable escuelas;
        DataTable respuesta;

        private DataSet dtsTablas = new DataSet();
        // int parametroActual;
        bool bandera;
        bool IsNuevo = true;
        bool IsEditar = false;

        private int IdPersonal;
        private string Escuela;

        public formNuevoEditarPersonal()
        {
            InitializeComponent();
            cargarEscuelas();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtDNI.Text == string.Empty)
                {
                    MensajeError("Falta ingresar DNI");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = LPersonal.InsertarPersonal(Convert.ToInt32(this.txtDNI.Text.Trim()),this.cbEscuela.Text, this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), this.txtObservaciones.Text.Trim());
                    }
                    else
                    {
                        rpta = LPersonal.EditarPersonal(this.IdPersonal, Convert.ToInt32(this.txtDNI), this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), this.txtObservaciones.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }
        private void cargarEscuelas()
        {
            escuelas = objetoCL_asistencia.ListarEscuelas();

            cbEscuela.DataSource = escuelas;

            cbEscuela.DisplayMember = "Escuela";
            cbEscuela.ValueMember = "IdEscuela";
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Asistec", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Asistec", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarEscuela_Click(object sender, EventArgs e)
        {
            formNuevaEditarEscuela frm = new formNuevaEditarEscuela();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // cboHojas.Items.Clear();
                // dgvDatos.DataSource = null;
                int i = 1;
                int j = 0;
                string rpta = "";

                // txtRuta.Text = oOpenFileDialog.FileName;

                //FileStream nos permite leer, escribir, abrir y cerrar archivos en un sistema de archivos, como matrices de bytes
                FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);


                //ExcelReaderFactory.CreateBinaryReader = formato XLS
                //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                //ExcelReaderFactory.CreateReader = XLS o XLSX
                IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(fsSource);

                DataSet result = excelReader.AsDataSet();
                // excelReader.IsFirstRowAsColumnNames = true;
                DataTable dt = result.Tables[0];
                

                while (i < excelReader.RowCount)
                {
                        string DNI = dt.Rows[i][j].ToString();
                        j = j+1;
                        string Apellidos = dt.Rows[i][j].ToString();
                        j = j+1;
                        string Nombres = dt.Rows[i][j].ToString();
                        j = j+1;
                        string Escuela = dt.Rows[i][j].ToString();
                        j = j+1;
                        string Observaciones = dt.Rows[i][j].ToString();
                        j = j+1;

                        rpta = LPersonal.InsertarPersonal(Convert.ToInt32(DNI.Trim()), Escuela.Trim(), Apellidos.Trim(), Nombres.Trim(), Observaciones.Trim());
                    
                    i = i+1;
                    j = 0;
                }

                /*foreach (DataTable dt in excelReader)
                {
                    string DNI = dt.Rows[1][0].ToString();
                }*/

                //convierte todas las hojas a un DataSet
                /*dtsTablas = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });*/

                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                /*foreach (DataTable tabla in dtsTablas.Tables)
                {
                    //cboHojas.Items.Add(tabla.TableName);
                }
                // cboHojas.SelectedIndex = 0;

                reader.Close();*/

            }
        }

        public bool CargarData(DataTable tbData)
        {
            bool resultado = true;
            /*using (SqlConnection cn = new SqlConnection(Configuracion.Conexion))
            {
                cn.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(cn))
                {

                    //ingresamos COLUMNAS ORIGEN | COLUMNAS DESTINOS
                    s.ColumnMappings.Add("Documento Identidad", "DocumentoIdentidad");
                    s.ColumnMappings.Add("Nombres", "Nombres");
                    s.ColumnMappings.Add("Telefono", "Telefono");
                    s.ColumnMappings.Add("Correo", "Correo");
                    s.ColumnMappings.Add("Ciudad", "Ciudad");

                    //definimos la tabla a cargar
                    s.DestinationTableName = "USUARIO";


                    s.BulkCopyTimeout = 1500;
                    try
                    {
                        s.WriteToServer(tbData);
                    }
                    catch (Exception e)
                    {
                        string st = e.Message;
                        resultado = false;
                    }


                }
            }
            */
            return resultado;
        }
    }
}
