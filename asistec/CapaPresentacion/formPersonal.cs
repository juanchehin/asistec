using asistec.CapaLogica;
using educatec.CapaLogica;
using System;
using System.Windows.Forms;

namespace educatec.CapaPresentacion
{
    public partial class formPersonal : Form
    {
        LPersonal objetoCL = new LPersonal();
        int DNI;
        string rpta;
        public formPersonal()
        {
            InitializeComponent();
            ListarPersonal();
        }

        private void btnNuevoPersonal_Click(object sender, EventArgs e)
        {
            formNuevoEditarPersonal frm = new formNuevoEditarPersonal();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        public void ListarPersonal()
        {
            dataListadoPersonal.DataSource = objetoCL.ListarPersonal();
            dataListadoPersonal.Columns[0].Visible = false;
            lblTotalPersonal.Text = Convert.ToString(dataListadoPersonal.Rows.Count);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ListarPersonal();
            this.txtDNI.Clear();
        }

        private void dataListadoPersonal_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoPersonal.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoPersonal.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoPersonal.Rows[selectedrowindex];
                this.DNI = Convert.ToInt32(selectedRow.Cells["DNI"].Value);
            }
        }

        private void btnMarcarAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                    rpta = LAsistencias.InsertarAsistencia(Convert.ToInt32(this.DNI), "-");

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOk("Asistencia marcada");
                    }
                    else
                    {
                        this.MensajeError(rpta);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.BuscarPersonal();
        }
        private void BuscarPersonal()
        {
            this.dataListadoPersonal.DataSource = objetoCL.BuscarPersonal(Convert.ToInt32(this.txtDNI.Text));
            lblTotalPersonal.Text = Convert.ToString(dataListadoPersonal.Rows.Count);
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.BuscarPersonal();
            }
        }
    }
}
