using asistec.CapaLogica;
using System;
using System.Windows.Forms;

namespace asistec.CapaPresentacion
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            formAcercaDe frm = new formAcercaDe();
            frm.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string Datos = LUsuarios.Login(this.txtUsuario.Text, this.txtPassword.Text);
            //Evaluar si existe el Usuario
            if (Datos != "Ok")
            {
                MessageBox.Show("Error de login", "Asistec", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                formInicio frm = new formInicio();
                frm.Show();
                this.Hide();

            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                string Datos = LUsuarios.Login(this.txtUsuario.Text, this.txtPassword.Text);
                //Evaluar si existe el Usuario
                if (Datos != "Ok")
                {
                    MessageBox.Show("Error de login", "Asistec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    formInicio frm = new formInicio();
                    frm.Show();
                    this.Hide();

                }
            }
        }
    }
}
