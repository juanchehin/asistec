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
            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarAsistencias(pFecha);
            return tabla;
        }

        public static string InsertarAsistencia(int DNI,string Observaciones)
        {
            DAsistencias Obj = new DAsistencias();
            Obj.DNI = DNI;
            Obj.Observaciones = Observaciones;

            return Obj.InsertarAsistencia(Obj);
        }
    }
}
