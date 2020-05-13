using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using AutoMapper;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext _dbContext;

        public IHttpActionResult GetMovies()
        {
           var moviedto = _dbContext.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviedto);
                
        }

        public IHttpActionResult GetMovies(int Id)
        {
            var Movie = _dbContext.Movies.SingleOrDefault(m => m.Id == Id);
            if (Movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(Movie));
        }
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + @"/" + movie.Id), movieDto);

        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public IHttpActionResult UpdateMovie(int Id, MovieDto movieDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieDb = _dbContext.Movies.SingleOrDefault(m => m.Id == Id);

            if (movieDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieDb);

            _dbContext.SaveChanges();

            return Ok();


        }
        
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public IHttpActionResult RemoveMovie(int Id)
        {

            var movieDb = _dbContext.Movies.SingleOrDefault(m => m.Id == Id);
            if (movieDb == null)
            {
                return NotFound();
            }
            _dbContext.Movies.Remove(movieDb);
            _dbContext.SaveChanges();
            return Ok();

        }
        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
    }
}
