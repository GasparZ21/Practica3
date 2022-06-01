using PeliculasClase.API.DTOs;

namespace PeliculasClase.API
{
    public class PeliculasData
    {
        public List<PeliculasDto> Peliculas { get; set; }
        public static PeliculasData InstanciaUnica { get; } = new PeliculasData();
        public PeliculasData()
        {
            Peliculas = new List<PeliculasDto>
            {
                new PeliculasDto()
                {
                    Id = 1,
                    Nombre = "La vida es bella",
                    Descripcion = "Drama",
                    Puntajes = new List<PuntajeDto>
                    {
                        new PuntajeDto()
                        {
                            Id= 1,
                            Pagina = "imdb",
                            Puntaje = 8
                        },

                        new PuntajeDto()
                        {
                            Id= 2,
                            Pagina = "sensacine",
                            Puntaje = 9
                        },

                    }

                },

                new PeliculasDto()
                {
                    Id = 2,
                    Nombre = "Gladiador",
                    Descripcion = "Accion",
                    Puntajes = new List<PuntajeDto>
                    {
                        new PuntajeDto()
                        {
                            Id= 3,
                            Pagina = "imdb",
                            Puntaje = 9
                        },

                        new PuntajeDto()
                        {
                            Id= 4,
                            Pagina = "sensacine",
                            Puntaje = 7
                        },

                    }
                },

                new PeliculasDto()
                {
                    Id = 3,
                    Nombre = "Mejor imposible",
                    Descripcion = "Comedia",
                     Puntajes = new List<PuntajeDto>
                     {
                        new PuntajeDto()
                        {
                            Id= 5,
                            Pagina = "imdb",
                            Puntaje = 10
                        },

                        new PuntajeDto()
                        {
                            Id= 6,
                            Pagina = "filmaffinity",
                            Puntaje = 9
                        },

                    }
                }

            };
        }
    }
}