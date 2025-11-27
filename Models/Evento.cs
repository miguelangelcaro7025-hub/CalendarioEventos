namespace CalendarioEventos.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Categoria { get; set; } = "General";
        public string Color { get; set; } = "#667eea";
        public bool TieneRecordatorio { get; set; }
    }
}