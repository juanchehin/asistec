namespace Asistec.API.Entities
{
    public class Asistencias
    {
        public int IdAsistencia { get; set; }
        public int IdPersonal { get; set; }
        public DateTime HorarioEntrada { get; set; }
        public DateTime HorarioSalida { get; set; }
        public string? Observaciones { get; set; }
    }
}
