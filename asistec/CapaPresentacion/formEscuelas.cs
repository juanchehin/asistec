using asistec.CapaLogica;
using System;
using System.Data;
using System.Windows.Forms;

namespace asistec.CapaPresentacion
{
    public partial class formEscuelas : Form
    {
        LEscuelas objetoCL = new LEscuelas();
        private int IdEscuela;
        int desde = 0;
        string totalEscuelas;
        DataSet ds = new DataSet();
        public formEscuelas()
        {
            InitializeComponent();
            ListarEscuelasPaginado(0);
        }

        public void ListarEscuelasPaginado(int pDesde)
        {
            ds = objetoCL.ListarEscuelasPaginado(pDesde);
            dataListadoEscuelas.DataSource = ds.Tables[0];
            totalEscuelas = ds.Tables[1].Rows[0][0].ToString();
            lblTotalEscuelas.Text = totalEscuelas;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ListarEscuelasPaginado(0);
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
                    this.ListarEscuelasPaginado(0);
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

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if ((desde + 10) >= Convert.ToInt32(totalEscuelas))
            {
                return;
            }

            if (desde < 0)
            {
                return;
            }

            //this.desde = this.desde + 10;
            this.desde += 10;
            this.ListarEscuelasPaginado(this.desde);
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (desde <= 0)
            {
                this.desde = 0;
                return;
            }
            //this.desde = this.desde - 10;
            this.desde -= 10;
            this.ListarEscuelasPaginado(this.desde);
        }

    }
}
