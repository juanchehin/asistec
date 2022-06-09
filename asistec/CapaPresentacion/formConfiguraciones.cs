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
            formCargando frm = new formCargando();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            Thread.Sleep(3000);

            try
            {
                Process.Start("C:\\asistec.exe");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ocurrio un problema, contactese con el administrador");
                MessageBox.Show("Chequee que exista asistec.exe en la ruta C:\\");
            }
            frm.Close();
        }
    }
}
