using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace educatec.CapaDatos
{
    public class DAsistencias
    {
        private int _IdAsistencia;
        private int _IdPersonal;
        private DateTime _HorarioEntrada;
        private DateTime _HorarioSalida;
        private string _Observaciones;

        public int IdAsistencia { get => _IdAsistencia; set => _IdAsistencia = value; }
        public int IdPersonal { get => _IdPersonal; set => _IdPersonal = value; }
        public DateTime HorarioEntrada { get => _HorarioEntrada; set => _HorarioEntrada = value; }
        public DateTime HorarioSalida { get => _HorarioSalida; set => _HorarioSalida = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }

        //Constructores
        public DAsistencias()
        {

        }

        public DAsistencias(int IdAsistencia, int IdPersonal, DateTime HorarioEntrada, DateTime HorarioSalida, string Observaciones)
        {
            this.IdAsistencia = IdAsistencia;
            this.IdPersonal = IdPersonal;
            this.HorarioEntrada = HorarioEntrada;
            this.HorarioSalida = HorarioSalida;
            this.Observaciones = Observaciones;

        }

        // ==================================================
        //  Permite devolver todos las asistencias de la BD
        // ==================================================
        private DConexion conexion = new DConexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();
        List<string> categorias = new List<string>();

        public DataTable ListarAsistencias(DateTime Fecha)
        {
            Console.WriteLine("Fecha en capa datos es : " + Fecha);

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_asistencias_por_dia";

            // Limpio el comando
            comando.Parameters.Clear();

            MySqlParameter pFecha = new MySqlParameter();
            pFecha.ParameterName = "@pFecha";
            pFecha.MySqlDbType = MySqlDbType.DateTime;
            // pIdProducto.Size = 60;
            pFecha.Value = Fecha;
            comando.Parameters.Add(pFecha);

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
    }
}
