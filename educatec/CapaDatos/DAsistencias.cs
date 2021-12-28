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

        private int _DNI;
        private string _Apellidos;
        private string _Nombres;

        public int IdAsistencia { get => _IdAsistencia; set => _IdAsistencia = value; }
        public int IdPersonal { get => _IdPersonal; set => _IdPersonal = value; }
        public DateTime HorarioEntrada { get => _HorarioEntrada; set => _HorarioEntrada = value; }
        public DateTime HorarioSalida { get => _HorarioSalida; set => _HorarioSalida = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }

        public int DNI { get => _DNI; set => _DNI = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }

        //Constructores
        public DAsistencias()
        {

        }

        public DAsistencias(int IdAsistencia, int IdPersonal, DateTime HorarioEntrada, DateTime HorarioSalida, string Observaciones,int DNI,string Apellidos,string Nombres)
        {
            this.IdAsistencia = IdAsistencia;
            this.IdPersonal = IdPersonal;
            this.HorarioEntrada = HorarioEntrada;
            this.HorarioSalida = HorarioSalida;
            this.Observaciones = Observaciones;

            this.DNI = DNI;
            this.Apellidos =Apellidos;
            this.Nombres = Nombres;

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

        public string InsertarAsistencia(DAsistencias Asistencia)
        {
            string rpta = "";
            // SqlConnection SqlCon = new SqlConnection();
            try
            {

                // Console.WriteLine("Producto es : " + Producto.Producto);

                //Código
                /*SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand(); */

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_asistencia";

                /*SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure; */


                MySqlParameter pDNI = new MySqlParameter();
                pDNI.ParameterName = "@pDNI";
                pDNI.MySqlDbType = MySqlDbType.VarChar;
                pDNI.Size = 60;
                pDNI.Value = Asistencia.DNI;
                comando.Parameters.Add(pDNI);

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Asistencia.Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pNombres = new MySqlParameter();
                pNombres.ParameterName = "@pNombres";
                pNombres.MySqlDbType = MySqlDbType.VarChar;
                pNombres.Size = 60;
                pNombres.Value = Asistencia.Nombres;
                comando.Parameters.Add(pNombres);

                Console.WriteLine("rpta es : " + rpta);

                // Console.WriteLine("el comando es : " + comando.CommandText[0]);
                //Ejecutamos nuestro comando

                // ExecuteNonQuery devuelve el numero de filas afectadas
                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
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
