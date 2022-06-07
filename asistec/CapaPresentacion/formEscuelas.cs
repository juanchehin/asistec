using asistec.CapaLogica;
using asistec.CapaPresentacion;
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
    public partial class formEscuelas : Form
    {
        LEscuelas objetoCN = new LEscuelas();
        private int IdEscuela;
        int desde = 0;
        int totalEscuelas = 0;
        public formEscuelas()
        {
            InitializeComponent();
            ListarEscuelas(0);
        }

        public void ListarEscuelas(int pDesde)
        {
            // Console.WriteLine("Ahora va el mostrar productos");
            dataListadoEscuelas.DataSource = objetoCN.ListarEscuelas(pDesde);
            dataListadoEscuelas.Columns[0].Visible = false;
            lblTotalEscuelas.Text = Convert.ToString(dataListadoEscuelas.Rows.Count);
            totalEscuelas = dataListadoEscuelas.Rows.Count;
            // this.banderaFormularioHijo = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ListarEscuelas(0);
        }

        private void btnAgregarEscuela_Click(object sender, EventArgs e)
        {
            formNuevaEditarEscuela frm = new formNuevaEditarEscuela();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar la escuela", "Asistec", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string rpta = LEscuelas.EliminarEscuela(this.IdEscuela);

                    if (rpta == "OK")
                    {
                        this.MensajeOk("Borrado con exito");
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.ListarEscuelas(0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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

        private void dataListadoEscuelas_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoEscuelas.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoEscuelas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoEscuelas.Rows[selectedrowindex];
                this.IdEscuela = Convert.ToInt32(selectedRow.Cells["IdEscuela"].Value);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.desde = this.desde - 15;

            if (desde >= this.totalEscuelas)
            {
                return;
            }

            if (desde < 0)
            {
                return;
            }

            //this.desde += valor;
            this.ListarEscuelas(this.desde);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.desde = this.desde + 15;

            if (desde >= this.totalEscuelas)
            {
                return;
            }

            if (desde < 0)
            {
                return;
            }

            //this.desde += valor;
            this.ListarEscuelas(this.desde);
        }
    }
}
