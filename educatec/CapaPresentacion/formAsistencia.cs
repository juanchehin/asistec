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
    public partial class formAsistencia : Form
    {
        LEscuelas objetoCL_asistencia = new LEscuelas();


        private DataTable escuelas;

        public formAsistencia()
        {
            InitializeComponent();
            cargarEscuelas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            /*try
            {
                string rpta = "";
                if (this.txtDNI.Text == string.Empty)
                {
                    MensajeError("El campo DNI es obligatorio");
                }
                else
                {
                    if (this.txtDNI.Text)
                    {
                        MensajeError("El campo DNI solo puede contener numeros");
                    }
                    else
                    {
                        rpta = CN_Clientes.Editar(this.IdCliente, this.txtTitular.Text.Trim(), this.txtTransporte.Text.Trim(), this.txtTelefono.Text.Trim());
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
            */
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Educatec", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Educatec", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cargarEscuelas()
        {
            escuelas = objetoCL_asistencia.ListarEscuelas();

            cbEscuelas.DataSource = escuelas;

            cbEscuelas.DisplayMember = "Escuela";
            cbEscuelas.ValueMember = "IdEscuela";
        }
    }
}
