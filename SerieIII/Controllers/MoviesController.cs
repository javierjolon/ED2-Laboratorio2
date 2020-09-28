using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SerieIII.Class;
using SerieIII.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SerieIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        MovieDataBase movieDB = new MovieDataBase();

        // GET: api/movies
        [HttpGet]
        public string Get()
        {
            var peliculas = movieDB.GetMovie();
            return peliculas;
        }

        // GET api/movies/recorrido
        [HttpGet("{recorrido}")]
        public string Get(string recorrido)
        {
            switch (recorrido)
            {
                case "inorden":
                    var peliculas = movieDB.inorden();
                    return peliculas;
                case "preorden":
                    peliculas = movieDB.preorden();
                    return peliculas;
                case "postorden":
                    peliculas = movieDB.postorden();
                    return peliculas;
                default:
                    peliculas = movieDB.GetMovie();
                    return peliculas;
            }
        }

        // POST api/movies/5
        [HttpPost]
        public IActionResult Post([FromBody] int orden)
        {
            try
            {
                movieDB.addOrderTree(orden);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
                throw;
            }
        }

        // POST api/movies/populate
        [HttpPost("{populate}")]
        public IActionResult Post([FromBody] Object peliculas)
        {
            JArray a = JArray.Parse(peliculas.ToString());

            try
            {
                foreach (JObject item in a.Children())
                {
                    Movie pelicula = new Movie();

                    string releaseDate = item.GetValue("releaseDate").ToString();
                    DateTime fecha = DateTime.Parse(releaseDate);
                    pelicula.Year = fecha.Year;
                    pelicula.Name = item.GetValue("title").ToString();
                    pelicula.Directed_by = item.GetValue("director").ToString();
                    pelicula.Stars = item.GetValue("imdbRating").ToString();
                    pelicula.Genre = item.GetValue("genre").ToString();

                    movieDB.AddNewMovie(item.GetValue("title").ToString(), pelicula);
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error");
                throw;
            }
        }

        // DELETE api/movies/
        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                movieDB.deleteCompleteTree();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
                throw;
            }
        }

        // DELETE api/movies/
        [HttpDelete("{populate}")]
        public IActionResult Delete(string id)
        {
            try
            {
                movieDB.deleteCompleteTree();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
                throw;
            }
        }

    }
}
