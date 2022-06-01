namespace Asistec.API.Entities
{
    public class Personal
    {
        public int IdPersonal { get; set; }
        public int IdEscuela { get; set; }
        public string? Apellidos { get; set; }
        public string? Nombres { get; set; }
        public int DNI { get; set; }
        public string? Estado { get; set; }
    }
}
