using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASPNetTest.Models;

namespace ASPNetTest.Controllers.API
{
    public class MoviesController : ApiController
    {
	    private ApplicationDbContext _context;

	    public MoviesController()
	    {
		    _context = new ApplicationDbContext();
	    }

        //GET api/movies
        public IHttpActionResult GetMovies()
        {
	        var movies = _context.Movies.ToList();

	        if (movies.Count == 0)
		        return NotFound();

            return Ok(movies);
        }

		//GET api/movies/1
		public IHttpActionResult GetMovie(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return NotFound();

			return Ok(movie);
		}

		//POST api/movies
		[HttpPost]
		public IHttpActionResult CreateMovie(Movie movie)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			_context.Movies.Add(movie);
			_context.SaveChanges();

			return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
		}

		//PUT /api/movies/1
		[HttpPut]
		public IHttpActionResult UpdateMovie(int id, Movie movie)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movieInDb == null)
				return NotFound();

			movieInDb.Name = movie.Name;
			movieInDb.GenreTypeId = movie.GenreTypeId;
			movieInDb.NumberInStock = movie.NumberInStock;
			movieInDb.ReleaseDate = movie.ReleaseDate;

			_context.SaveChanges();

			return Ok(movie);
		}

		//DELETE /api/users/1
		[HttpDelete]
		public IHttpActionResult DeleteMovie(int id)
		{
			var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movieInDb == null)
				return NotFound();

			_context.Movies.Remove(movieInDb);
			_context.SaveChanges();

			return Ok();
		}
    }
}
