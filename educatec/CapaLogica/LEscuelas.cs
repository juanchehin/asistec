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
    }

    
}
