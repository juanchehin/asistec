using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace educatec.CapaDatos
{
    public class DConexion
    {
        MySqlConnection Con = new MySqlConnection("datasource =localhost;username = root;password = '';database=educatec");

        public DConexion()
        {
            AbrirConexion();
        }
        public MySqlConnection AbrirConexion()
        {
            // string ConnectString = "datasource = localhost;username = root;password =;database=gomerialeon";
            // ConectionString => "datasource =localhost;username = root;password =;database=gomerialeon"
            try
            {
                // MessageBox.Show("Estas conectado!");
                Con.Open();
                return Con;
            }
            catch
            {
                // MessageBox.Show(e.Message);
                return Con;
            }
        }

        public MySqlConnection CerrarConexion()
        {
            // string ConnectString = "datasource = localhost;username = root;password =;database=gomerialeon";
            // MySqlConnection Con = new MySqlConnection("datasource = localhost;username = root;password =;database=gomerialeon");
            try
            {
                Con.Close();
                // MessageBox.Show("Conexion cerrada!");
                return Con;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return Con;
            }
        }
    }
}
