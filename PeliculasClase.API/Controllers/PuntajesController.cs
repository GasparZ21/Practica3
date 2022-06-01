using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliculasClase.API.DTOs;

namespace PeliculasClase.API.Controllers
{
    [Route("api/peliculas/{idPelicula}/puntajes")]
    [ApiController]
    public class PuntajesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PuntajeDto>> GetPuntajes(int idPelicula)
        {
            var pelicula = PeliculasData.InstanciaUnica.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if(pelicula == null)
                return NotFound();
            return Ok(pelicula.Puntajes);
        }

        [HttpGet("{IdPuntaje}", Name ="GetPuntajes")]
        public ActionResult<PuntajeDto> GetPuntajes(int idPelicula, int idPuntaje)
        {
            var pelicula = PeliculasData.InstanciaUnica.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if (pelicula == null)
                return NotFound();

            var puntaje = pelicula.Puntajes.Where(x => x.Id == idPuntaje).FirstOrDefault();
            if (puntaje == null)
                return NotFound();

            return Ok(puntaje);

        }

        [HttpPost]
        public ActionResult<PuntajeDto> CrearPuntaje(int idPelicula, PuntajeParaCreacionDto PuntajeACrear)
        {
            var pelicula = PeliculasData.InstanciaUnica.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if (pelicula == null)
                return NotFound();

            var idMaximoPuntaje = PeliculasData.InstanciaUnica.Peliculas.SelectMany(c => c.Puntajes).Max(p => p.Id);

            var nuevoPuntaje = new PuntajeDto
            {
                Id = idMaximoPuntaje + 1,
                Pagina = PuntajeACrear.Pagina,
                Puntaje = PuntajeACrear.Puntaje
            };

            pelicula.Puntajes.Add(nuevoPuntaje);

            return CreatedAtRoute("GetPuntajes",
                new
                {
                    idPelicula,
                    idPuntaje = nuevoPuntaje.Id,
                },
                nuevoPuntaje);
        }

        [HttpPut("{IdPuntaje}")]
        public ActionResult ActualizarPuntaje(int idPelicula, int idPuntaje, PuntajeParaActualizarDto PuntajeActualizado)
        {
            var pelicula = PeliculasData.InstanciaUnica.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if (pelicula == null)
                return NotFound();

            var PuntajeActualizar = pelicula.Puntajes.Where(p => p.Id == idPuntaje).FirstOrDefault();
            if (PuntajeActualizar == null)
                return NotFound();

            PuntajeActualizar.Pagina = PuntajeActualizado.Pagina;
            PuntajeActualizar.Puntaje = PuntajeActualizado.Puntaje;

            return NoContent();
        }

        [HttpDelete("{IdPuntaje}")]
        public ActionResult EliminarPuntaje(int idPelicula, int idPuntaje)
        {
            var pelicula = PeliculasData.InstanciaUnica.Peliculas.Where(x => x.Id == idPelicula).FirstOrDefault();
            if (pelicula == null)
                return NotFound();

            var PuntajeEliminar = pelicula.Puntajes.Where(p => p.Id == idPuntaje).FirstOrDefault();
            if (PuntajeEliminar == null)
                return NotFound();

            pelicula.Puntajes.Remove(PuntajeEliminar);

            return NoContent();
        }

    }
}
