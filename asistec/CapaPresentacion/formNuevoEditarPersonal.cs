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
        private DataSet escuelas;
        DataTable respuesta;

        private DataSet dtsTablas = new DataSet();
        private DataTable dt = new DataTable();
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
                        rpta = LPersonal.InsertarPersonal(this.txtDNI.Text.Trim(),this.cbEscuela.Text, this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), this.txtObservaciones.Text.Trim());
                    }
                    else
                    {
                        rpta = LPersonal.EditarPersonal(this.IdPersonal, this.txtDNI.Text.Trim(), this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), this.txtObservaciones.Text.Trim());
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

            dt = escuelas.Tables[0];

            cbEscuela.DataSource = dt;

            cbEscuela.DisplayMember = "Escuela";
            cbEscuela.ValueMember = "IdEscuela";
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
            // cargando page = new cargando();
            // frm.MdiParent = this.MdiParent;
            // page.Show();
            try
            {

            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {

                int i = 1;
                int j = 0;
                int regCargados = 0;
                string rpta;

                //FileStream nos permite leer, escribir, abrir y cerrar archivos en un sistema de archivos, como matrices de bytes
                FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);

                //ExcelReaderFactory.CreateBinaryReader = formato XLS
                //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                //ExcelReaderFactory.CreateReader = XLS o XLSX
                IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(fsSource);

                DataSet result = excelReader.AsDataSet();
                // excelReader.IsFirstRowAsColumnNames = true;
                DataTable dt = result.Tables[0];

                formCargando page = new formCargando();
                page.MdiParent = this.MdiParent;
                page.Show();

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

                        rpta = LPersonal.InsertarPersonal(DNI.Trim(), Escuela.Trim(), Apellidos.Trim(), Nombres.Trim(), Observaciones.Trim());
                        
                        if(rpta == "Ok" || rpta == "OK")
                        {
                            regCargados++;
                        }
                    i = i+1;
                    j = 0;
                }

                page.Dispose();
                MensajeOk("Se cargaron " + regCargados + " registros en la Base de datos");
            }


            }
            catch(Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Asistec", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Asistec", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


    }
}
