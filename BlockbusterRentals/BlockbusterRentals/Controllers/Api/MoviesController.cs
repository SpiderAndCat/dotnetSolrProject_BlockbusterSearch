using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlockbusterRentals.Dtos;
using AutoMapper;
using BlockbusterRentals.Models;
using System.Web.Http;
using System.Net;

namespace BlockbusterRentals.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        // getting an object

        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            // add new customerDto to _context
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            // get customerDto in DB to update
            var movieInDb = _context.Movies.SingleOrDefault(C => C.Id == id);

            // check for existance and validity of id
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            // update movieDto

            _context.SaveChanges();

        }


        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            // check if customerDto exists
            var movieInDb = _context.Customers.SingleOrDefault(C => C.Id == id);

            // check for existance and validity of id
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(movieInDb);
            _context.SaveChanges();



            _context.SaveChanges();

        }
    }
}