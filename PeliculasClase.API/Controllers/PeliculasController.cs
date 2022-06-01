using Microsoft.AspNetCore.Mvc;

namespace PeliculasClase.API.Controllers
{
    [ApiController]
    [Route("[api/peliculas]")]
    public class PeliculasController : ControllerBase
    {
        [HttpGet]

        public JsonResult GetPeliculas()
        {
            return new JsonResult(PeliculasData.InstanciaUnica.Peliculas);
        }

        [HttpGet("{idPelicula}")]
        public IActionResult GetPeliculas(int idPelicula)
        {
            var pelicula = PeliculasData.InstanciaUnica.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }
    }