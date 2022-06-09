using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace asistec.CapaPresentacion
{
    public partial class formIP : Form
    {
        public formIP()
        {
            InitializeComponent();
            obtenerIp();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void obtenerIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    this.lbIP.Text = ip.ToString();
                }
            }
        }
    }
}
