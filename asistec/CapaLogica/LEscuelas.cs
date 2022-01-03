using educatec.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace educatec.CapaLogica
{
    public class LEscuelas
    {
        private DEscuelas objetoCD = new DEscuelas();

        public int IdEscuela { get; set; }
        public string Escuela { get; set; }
        public string Observaciones { get; set; }

        public DataTable ListarEscuelas()
        {

            DataTable tablaEscuelas = new DataTable();
            tablaEscuelas = objetoCD.ListarEscuelas();
            return tablaEscuelas;
        }
        //Método Insertar que llama al método Insertar de la clase
        //de la CapaDatos
        public static string InsertarEscuela(string Escuela, string Observaciones)
        {
            // Console.WriteLine("En insertar , nombre es " + nombre);
            // Console.WriteLine("Escuela en logica es : " + Escuela);

            DEscuelas Obj = new DEscuelas();
            Obj.Escuela = Escuela;
            Obj.Observaciones = Observaciones;

            return Obj.InsertarEscuela(Obj);
        }

        public DataTable DameEscuela(int IdEscuela)
        {

            DataTable tabla = new DataTable();
            // tabla = objetoCD.DameEscuela(IdProducto);
            Console.WriteLine("tabla TableName en capa negocio es : " + tabla.TableName);
            Console.WriteLine("tabla Rows en capa negocio es : " + tabla.Rows);
            return tabla;
        }
        public static string EliminarEscuela(int IdEscuela)
        {
            
            DEscuelas Obj = new DEscuelas();
            // Obj.IdEscuela = IdEscuela;
            // Console.WriteLine("Obj en capa negocio es : " + Obj.EliminarEscuela(IdEscuela));
            return Obj.EliminarEscuela(IdEscuela);
        }
    }

    
}
