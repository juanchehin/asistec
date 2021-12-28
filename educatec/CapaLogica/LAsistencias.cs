using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace educatec.CapaLogica
{
    public class LAsistencias
    {
        public int IdAsistencia  { get; set; }
        public int IdPersonal { get; set; }

        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Observaciones { get; set; }
    }
}
