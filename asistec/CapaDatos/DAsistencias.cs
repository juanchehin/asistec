using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace asistec.CapaDatos
{
    public class DAsistencias
    {
        private int _IdAsistencia;
        private int _IdPersonal;
        private DateTime _HorarioEntrada;
        private DateTime _HorarioSalida;
        private string _Observaciones;
        private string _Escuela;

        private int _DNI;

        public int IdAsistencia { get => _IdAsistencia; set => _IdAsistencia = value; }
        public int IdPersonal { get => _IdPersonal; set => _IdPersonal = value; }
        public string Escuela { get => _Escuela; set => _Escuela = value; }
        public DateTime HorarioEntrada { get => _HorarioEntrada; set => _HorarioEntrada = value; }
        public DateTime HorarioSalida { get => _HorarioSalida; set => _HorarioSalida = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }

        public int DNI { get => _DNI; set => _DNI = value; }

        //Constructores
        public DAsistencias()
        {

        }

        public DAsistencias(int IdAsistencia, int IdPersonal, DateTime HorarioEntrada, DateTime HorarioSalida, string Observaciones,int DNI,string Apellidos,string Nombres,string Escuela)
        {
            this.IdAsistencia = IdAsistencia;
            this.IdPersonal = IdPersonal;
            this.HorarioEntrada = HorarioEntrada;
            this.HorarioSalida = HorarioSalida;
            this.Observaciones = Observaciones;
            this.Escuela = Escuela;

            this.DNI = DNI;

        }

        // ==================================================
        //  Permite devolver todos las asistencias de la BD
        // ==================================================
        private DConexion conexion = new DConexion();

        MySqlCommand comando = new MySqlCommand();

        public DataSet ListarAsistencias(DateTime Fecha, int pDesde)
        {
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

            MySqlParameter desde = new MySqlParameter();
            desde.ParameterName = "@pDesde";
            desde.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            desde.Value = pDesde;
            comando.Parameters.Add(desde);

            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);

            comando.Parameters.Clear();
            conexion.CerrarConexion();
            
            return ds;

        }

        public string InsertarAsistencia(DAsistencias Asistencia)
        {
            string rpta = "";
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_asistencia";

                MySqlParameter pDNI = new MySqlParameter();
                pDNI.ParameterName = "@pDNI";
                pDNI.MySqlDbType = MySqlDbType.VarChar;
                pDNI.Size = 60;
                pDNI.Value = Asistencia.DNI;
                comando.Parameters.Add(pDNI);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 255;
                pObservaciones.Value = Asistencia.Observaciones;
                comando.Parameters.Add(pObservaciones);

                rpta = comando.ExecuteScalar().ToString();
                comando.Parameters.Clear();

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return rpta;

        }

        
    }
}
