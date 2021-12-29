using educatec.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace educatec.CapaLogica
{
    public class LAsistencias
    {
        private DAsistencias objetoCD = new DAsistencias();

        public DataTable ListarAsistencias(DateTime pFecha)
        {
            Console.WriteLine("pFecha en capa logicaa es : " + pFecha);
            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarAsistencias(pFecha);
            return tabla;
        }

        public static string InsertarAsistencia(int DNI,string Observaciones,string Escuela)
        {
            // Console.WriteLine("En insertar , nombre es " + nombre);

            DAsistencias Obj = new DAsistencias();
            Obj.DNI = DNI;
            Obj.Observaciones = Observaciones;
            Obj.Escuela = Escuela;

            return Obj.InsertarAsistencia(Obj);
        }
    }
}
