﻿using MySql.Data.MySqlClient;
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

        public DataTable ListarEscuelas()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_listar_escuelas";


            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            return tabla;

        }
        public string InsertarEscuela(DEscuelas Escuela)
        {
            string rpta = "";
            try
            {

                Console.WriteLine("Escuela es : " + Escuela.Escuela);
                Console.WriteLine("Observaciones es : " + Escuela.Observaciones);

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

                

                Console.WriteLine("el comando es : " + comando.CommandText);
                //Ejecutamos nuestro comando

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
                Console.WriteLine("El Escuela es " + IdEscuela);

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
                //if (conexion. == ConnectionState.Open) 
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }
    }
}
