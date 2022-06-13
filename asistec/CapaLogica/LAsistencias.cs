using asistec.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asistec.CapaLogica
{
    public class LAsistencias
    {
        private DAsistencias objetoCD = new DAsistencias();

        public DataSet ListarAsistencias(DateTime pFecha,int pDesde)
        {
            //DataTable tabla = new DataTable();
            //tabla = objetoCD.ListarAsistencias(pFecha,pDesde);
            //return tabla;
            DataSet tabla = new DataSet();
            tabla = objetoCD.ListarAsistencias(pFecha,pDesde);
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
