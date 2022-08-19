using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asistec.CapaDatos
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

        public DataSet ListarEscuelas()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_listar_escuelas";

            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);

            comando.Parameters.Clear();

            conexion.CerrarConexion();

            return ds;

        }

        public DataSet ListarEscuelasPaginado(int pDesde)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_listar_escuelas_paginado";

            MySqlParameter desde = new MySqlParameter();
            desde.ParameterName = "@pDesde";
            desde.MySqlDbType = MySqlDbType.Int32;
            //pDesde.Size = 60;
            desde.Value = pDesde;
            comando.Parameters.Add(desde);

            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);

            comando.Parameters.Clear();

            conexion.CerrarConexion();

            return ds;

        }
        public string InsertarEscuela(DEscuelas Escuela)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_escuela";

                MySqlParameter pEscuela= new MySqlParameter();
                pEscuela.ParameterName = "@pEscuela";
                pEscuela.MySqlDbType = MySqlDbType.VarChar;
                pEscuela.Size = 60;
                pEscuela.Value = Escuela.Escuela;
                comando.Parameters.Add(pEscuela);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 255;
                pObservaciones.Value = Escuela.Observaciones;
                comando.Parameters.Add(pObservaciones);

                rpta = comando.ExecuteScalar().ToString() == "OK" ? "OK" : "No se edito el Registro";
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
        public string EliminarEscuela(int IdEscuela)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_escuela";

                MySqlParameter pIdEscuela = new MySqlParameter();
                pIdEscuela.ParameterName = "@pIdEscuela";
                pIdEscuela.MySqlDbType = MySqlDbType.Int32;
                pIdEscuela.Value = IdEscuela;
                comando.Parameters.Add(pIdEscuela);

                //Ejecutamos nuestro comando
                if(comando.ExecuteScalar().ToString() == "OK")
                {
                    rpta = "OK";
                }
                else
                {
                    rpta = comando.ExecuteScalar().ToString();
                }

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }
    }
}
