using asistec.CapaDatos;
using System;
using System.Data;

namespace asistec.CapaLogica
{
    public class LPersonal
    {
        private DPersonal objetoCD = new DPersonal();

        public int IdPersonal { get; set; }
        public string Escuela { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public int DNI { get; set; }

        public static string InsertarPersonal(int DNI,string Escuela,string Apellidos, string Nombres, string Observaciones)
        {
            DPersonal Obj = new DPersonal();
            Obj.DNI = DNI;
            Obj.Escuela = Escuela;
            Obj.Apellidos = Apellidos;
            Obj.Nombres = Nombres;
            Obj.Observaciones = Observaciones;

            return Obj.InsertarPersonal(Obj);
        }

        public DataTable ListarPersonal()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarPersonal();
            return tabla;
        }
        public static string EliminarPersonal(int IdPersonal)
        {
            DPersonal Obj = new DPersonal();
            Obj.IdPersonal = IdPersonal;
            return Obj.EliminarPersonal(Obj);
        }

        // Devuelve solo un Personal
        public DataTable DamePersonal(int IdPersonal)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.DamePersonal(IdPersonal);
            Console.WriteLine("tabla TableName en capa negocio es : " + tabla.TableName);
            Console.WriteLine("tabla Rows en capa negocio es : " + tabla.Rows);
            return tabla;
        }

        public static string EditarPersonal(int IdPersonal,int DNI, string Apellidos, string Nombres, string Observaciones)
        {

            DPersonal Obj = new DPersonal();
            Obj.IdPersonal = IdPersonal;

            Obj.DNI = DNI;
            Obj.Apellidos = Apellidos;
            Obj.Nombres = Nombres;
            Obj.Observaciones = Observaciones;

            return Obj.EditarPersonal(Obj);
        }

        public DataTable BuscarPersonal(int DNI)
        {
            DPersonal Obj = new DPersonal();
            return Obj.BuscarPersonal(DNI);
        }
    }
}
