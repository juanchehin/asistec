using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace asistec.CapaDatos
{
    public class DPersonal
    {
        private int _IdPersonal;
        private string _Escuela;
        private string _Apellidos;
        private string _Nombres;
        private string _DNI;
        private string _Observaciones;

        private string _TextoBuscar;


        public int IdPersonal { get => _IdPersonal; set => _IdPersonal = value; }
        public string Escuela { get => _Escuela; set => _Escuela = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string DNI { get => _DNI; set => _DNI = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores
        public DPersonal()
        {

        }

        public DPersonal(int IdPersonal, string Escuela, string DNI, string Apellidos, string Nombres, string Observaciones)
        {
            this.IdPersonal = IdPersonal;
            this.Escuela = Escuela;
            this.DNI = DNI;
            this.Apellidos = Apellidos;
            this.Nombres = Nombres;
            this.Observaciones = Observaciones;
        }

        private DConexion conexion = new DConexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();


        public DataSet ListarPersonal(int pDesde)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_listar_personal";

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

        public DataTable BuscarPersonal(int DNI)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_buscar_personal";

            MySqlParameter pDNI = new MySqlParameter();
            pDNI.ParameterName = "@pDNI";
            pDNI.MySqlDbType = MySqlDbType.Int32;
            pDNI.Value = DNI;
            comando.Parameters.Add(pDNI);

            leer = comando.ExecuteReader();
            tabla.Load(leer);

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;

        }

        public string EditarPersonal(DPersonal Personal)
        {
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_personal";

                MySqlParameter pIdPersonal = new MySqlParameter();
                pIdPersonal.ParameterName = "@pIdPersonal";
                pIdPersonal.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdPersonal.Value = Personal.IdPersonal;
                comando.Parameters.Add(pIdPersonal);

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Personal.Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pNombres = new MySqlParameter();
                pNombres.ParameterName = "@pNombres";
                pNombres.MySqlDbType = MySqlDbType.VarChar;
                pNombres.Size = 30;
                pNombres.Value = Personal.Nombres;
                comando.Parameters.Add(pNombres);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 15;
                pObservaciones.Value = Personal.Observaciones;
                comando.Parameters.Add(pObservaciones);

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "OK" : "No se edito el Registro";

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

        //Métodos
        //Insertar
        public string InsertarPersonal(DPersonal Personal)
        {
            string rpta = "";
            try
            {

                
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_personal";

                MySqlParameter pDNI = new MySqlParameter();
                pDNI.ParameterName = "@pDNI";
                pDNI.MySqlDbType = MySqlDbType.Int32;
                pDNI.Size = 11;
                pDNI.Value = Personal.DNI;
                comando.Parameters.Add(pDNI);

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Personal.Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pNombres = new MySqlParameter();
                pNombres.ParameterName = "@pNombres";
                pNombres.MySqlDbType = MySqlDbType.VarChar;
                pNombres.Size = 60;
                pNombres.Value = Personal.Nombres;
                comando.Parameters.Add(pNombres);

                MySqlParameter pEscuela = new MySqlParameter();
                pEscuela.ParameterName = "@pEscuela";
                pEscuela.MySqlDbType = MySqlDbType.VarChar;
                pEscuela.Size = 60;
                pEscuela.Value = Personal.Escuela;
                comando.Parameters.Add(pEscuela);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 250;
                pObservaciones.Value = Personal.Observaciones;
                comando.Parameters.Add(pObservaciones);


                rpta = comando.ExecuteScalar().ToString();
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

        public string EliminarPersonal(DPersonal Personal)
        {
            string rpta = "";
            try
            {

                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_personal";

                MySqlParameter pIdPersonal = new MySqlParameter();
                pIdPersonal.ParameterName = "@pIdPersonal";
                pIdPersonal.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdPersonal.Value = Personal.IdPersonal;
                comando.Parameters.Add(pIdPersonal);

                rpta = comando.ExecuteScalar().ToString() == "OK" ? "OK" : "No se inserto el Registro";


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

        // devuelve solo 1 personal de la BD
        public DataTable DamePersonal(int IdCliente)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_personal";

            MySqlParameter pIdPersonal = new MySqlParameter();
            pIdPersonal.ParameterName = "@pIdPersonal";
            pIdPersonal.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            pIdPersonal.Value = IdPersonal;
            comando.Parameters.Add(pIdPersonal);

            leer = comando.ExecuteReader();
            tabla.Load(leer);

            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;

        }
    }
}
