using System.ComponentModel.DataAnnotations;

namespace PeliculasClase.API.DTOs
{
    public class PuntajeParaCreacionDto
    {
        [Required(ErrorMessage = "Agrega un pagina")]
        [MaxLength(50)]
        public string Pagina { get; set; } = string.Empty;

        [MaxLength(100)]
        public int Puntaje { get; set; }
    }
}
