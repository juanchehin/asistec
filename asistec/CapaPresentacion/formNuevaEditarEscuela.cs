using asistec.CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asistec.CapaPresentacion
{
    public partial class formNuevaEditarEscuela : Form
    {
        LEscuelas objetoCN = new LEscuelas();
        DataTable respuesta;
        // int parametroActual;
        bool bandera = true;
        bool IsNuevo = false;
        bool IsEditar = false;
        public formNuevaEditarEscuela()
        {
            InitializeComponent();
            // this.bandera = IsNuevoEditar;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtEscuela.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        Console.WriteLine("Pasa 1");
                        rpta = LEscuelas.InsertarEscuela(this.txtEscuela.Text.Trim(), this.txtObservaciones.Text.Trim());
                    }
                    else
                    {
                        Console.WriteLine("Pasa 2");
                        // rpta = LEscuelas.EditarEscuela(this.IdEscuela, this.txtEscuela.Text.Trim(), this.txtObservaciones.Text.Trim());
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

        private void formNuevaEditarEscuela_Load(object sender, EventArgs e)
        {
            // this.ActiveControl = txtNombre;
            if (this.bandera)
            {
                lblEditarNuevo.Text = "Nueva escuela";
                // this.MostrarProducto(this.IdProducto);
                this.IsNuevo = true;
                this.IsEditar = false;
            }
            else
            {
                lblEditarNuevo.Text = "Editar escuela";
                this.IsNuevo = false;
                this.IsEditar = true;
                // this.DameEscuela(this.IdEscuela);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
