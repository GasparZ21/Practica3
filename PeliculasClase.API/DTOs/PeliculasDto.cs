namespace PeliculasClase.API.DTOs
{
    public class PeliculasDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }

        public IList<PuntajeDto> Puntajes { get; set; } = new List<PuntajeDto>();

        public int CantidadDePuntaje
        {
            get { return Puntajes.Count; }
        }
    }
}

