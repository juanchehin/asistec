using asistec.CapaLogica;
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
    public partial class formNuevoEditarPersonal : Form
    {
        LPersonal objetoCN = new LPersonal();
        DataTable respuesta;
        // int parametroActual;
        bool bandera;
        bool IsNuevo = false;
        bool IsEditar = false;

        private int IdPersonal;

        public formNuevoEditarPersonal()
        {
            InitializeComponent();
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
                        rpta = LPersonal.InsertarPersonal(Convert.ToInt32(this.txtDNI), this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), this.txtObservaciones.Text.Trim());
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
