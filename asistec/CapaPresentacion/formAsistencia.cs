using asistec.CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asistec.CapaPresentacion
{
    public partial class formAsistencia : Form
    {
        LEscuelas objetoCL_asistencia = new LEscuelas();
        private DataTable escuelas;
        private string escuela;

        public formAsistencia()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.guardarAsistencia();
        }        

        private void btnAgregarEscuela_Click(object sender, EventArgs e)
        {
            formNuevaEditarEscuela frm = new formNuevaEditarEscuela();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.guardarAsistencia();
            }
        }

        private void guardarAsistencia()
        {
            int i;
            string rpta = "";
            try
            {
                if (int.TryParse(txtDNI.Text, out i).ToString() == "False")
                {
                    MensajeError("El campo DNI debe ser numerico");
                    return;
                }
                if (this.txtDNI.Text == string.Empty)
                {
                    MensajeError("El campo DNI es obligatorio");
                }
                else
                {
                    rpta = LAsistencias.InsertarAsistencia(Convert.ToInt32(txtDNI.Text), this.tbObservaciones.Text.Trim());

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se Insertó de forma correcta el registro");
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
            txtDNI.Clear();
            tbObservaciones.Clear();
        }
        //Mostrar Mensaje de Error
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
