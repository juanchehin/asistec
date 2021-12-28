using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace educatec.CapaDatos
{
    public class DEscuelas
    {
        private int _IdEscuela;
        private string _Escuela;
        private string _Observaciones;

        public int IdEscuela { get => _IdEscuela; set => _IdEscuela = value; }
        public string Escuela { get => _Escuela; set => _Escuela = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }

        //Constructores
        public DEscuelas()
        {

        }

        public DEscuelas(int IdEscuela, string Escuela, string Observaciones)
        {
            this.IdEscuela = IdEscuela;
            this.Escuela = Escuela;
            this.Observaciones = Observaciones;

        }

        private DConexion conexion = new DConexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        // ==================================================
        //  Permite devolver todos las escuelas de la BD
        // ==================================================
        public DataTable ListarEscuelas()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_listar_escuelas";


            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            // conexion.CerrarConexion();
            return tabla;

        }
    }
}
