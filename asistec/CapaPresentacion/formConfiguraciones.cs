using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace asistec.CapaPresentacion
{
    public partial class formConfiguraciones : Form
    {
        string archivoSeleccionado;
        public formConfiguraciones()
        {
            InitializeComponent();
        }

        private void btnIP_Click(object sender, EventArgs e)
        {
            formIP frm = new formIP();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnBackEnd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "File (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.archivoSeleccionado = openFileDialog1.FileName;
            }

            try
            {
                Process.Start(this.archivoSeleccionado);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ocurrio un problema, contactese con el administrador");
            }
        }
    }
}
