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
        public string DNI { get; set; }

        public static string InsertarPersonal(string DNI,string Escuela,string Apellidos, string Nombres, string Observaciones)
        {
            DPersonal Obj = new DPersonal();
            Obj.DNI = DNI;
            Obj.Escuela = Escuela;
            Obj.Apellidos = Apellidos;
            Obj.Nombres = Nombres;
            Obj.Observaciones = Observaciones;

            return Obj.InsertarPersonal(Obj);
        }

        public DataSet ListarPersonal(int pDesde)
        {

            DataSet tabla = new DataSet();
            tabla = objetoCD.ListarPersonal(pDesde);
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
            return tabla;
        }

        public static string EditarPersonal(int IdPersonal, string DNI, string Apellidos, string Nombres, string Observaciones)
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
