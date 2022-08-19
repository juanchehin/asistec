using asistec.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asistec.CapaLogica
{
    public class LEscuelas
    {
        private DEscuelas objetoCD = new DEscuelas();

        public int IdEscuela { get; set; }
        public string Escuela { get; set; }
        public string Observaciones { get; set; }

        public DataSet ListarEscuelas()
        {
            DataSet tabla = new DataSet();
            tabla = objetoCD.ListarEscuelas();
            return tabla;
        }

        public DataSet ListarEscuelasPaginado(int pDesde)
        {
            DataSet tabla = new DataSet();
            tabla = objetoCD.ListarEscuelasPaginado(pDesde);
            return tabla;
        }
        //Método Insertar que llama al método Insertar de la clase
        //de la CapaDatos
        public static string InsertarEscuela(string Escuela, string Observaciones)
        {

            DEscuelas Obj = new DEscuelas();
            Obj.Escuela = Escuela;
            Obj.Observaciones = Observaciones;

            return Obj.InsertarEscuela(Obj);
        }

        public DataTable DameEscuela(int IdEscuela)
        {

            DataTable tabla = new DataTable();
            return tabla;
        }
        public static string EliminarEscuela(int IdEscuela)
        {
            
            DEscuelas Obj = new DEscuelas();
            return Obj.EliminarEscuela(IdEscuela);
        }
    }

    
}
