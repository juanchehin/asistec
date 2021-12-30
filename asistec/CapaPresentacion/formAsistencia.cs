using educatec.CapaLogica;
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

namespace educatec.CapaPresentacion
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

                        // this.Close();
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

        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtDNI.Text == string.Empty)
                {
                    MensajeError("El campo DNI es obligatorio y debe ser numerico");
                }
                else
                {
                    rpta = LAsistencias.InsertarAsistencia(Convert.ToInt32(txtDNI),this.tbObservaciones.Text.Trim());

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se Insertó de forma correcta el registro");
                        
                        // this.Close();
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

        }

        private void btnAgregarEscuela_Click(object sender, EventArgs e)
        {
            formNuevaEditarEscuela frm = new formNuevaEditarEscuela();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }*/
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtDNI.Text, "  ^ [0-9]"))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtDNI.Text = "";
            }
        }
    }
}
