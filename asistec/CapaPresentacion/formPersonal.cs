using asistec.CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace asistec.CapaPresentacion
{
    public partial class formPersonal : Form
    {
        LPersonal objetoCL = new LPersonal();
        int DNI;
        int desde = 0;
        string totalPersonal;
        string rpta;
        private int IdPersonal;
        DataSet ds = new DataSet();
        public formPersonal()
        {
            InitializeComponent();
            ListarPersonal(0);
        }

        private void btnNuevoPersonal_Click(object sender, EventArgs e)
        {
            formNuevoEditarPersonal frm = new formNuevoEditarPersonal();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        public void ListarPersonal(int pDesde)
        {
            ds = objetoCL.ListarPersonal(pDesde);
            dataListadoPersonal.DataSource = ds.Tables[0];
            totalPersonal = ds.Tables[1].Rows[0][0].ToString();
            lblTotalPersonal.Text = totalPersonal;
            DataGridViewColumn column = dataListadoPersonal.Columns[6];
            column.Width = 180;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ListarPersonal(0);
            this.txtDNI.Clear();
        }

        private void dataListadoPersonal_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoPersonal.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoPersonal.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoPersonal.Rows[selectedrowindex];
                this.DNI = Convert.ToInt32(selectedRow.Cells["DNI"].Value);
                this.IdPersonal = Convert.ToInt32(selectedRow.Cells["IdPersonal"].Value);
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
            if(!String.IsNullOrEmpty(this.txtDNI.Text))
            {
                this.dataListadoPersonal.DataSource = objetoCL.BuscarPersonal(Convert.ToInt32(this.txtDNI.Text));
                lblTotalPersonal.Text = Convert.ToString(dataListadoPersonal.Rows.Count);
            }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar el personal", "Asistec", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string rpta = LPersonal.EliminarPersonal(this.IdPersonal);

                    if (rpta == "OK")
                    {
                        this.MensajeOk("Borrado con exito");
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.ListarPersonal(0);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if ((desde + 20) >= Convert.ToInt32(totalPersonal))
            {
                return;
            }

            if (desde < 0)
            {
                return;
            }

            this.desde += 20;
            this.ListarPersonal(this.desde);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (desde <= 0)
            {
                this.desde = 0;
                return;
            }
            //this.desde = this.desde - 10;
            this.desde -= 20;
            this.ListarPersonal(this.desde);
        }
    }
}
