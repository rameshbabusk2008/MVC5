using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _dbContext;

        public MovieController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        public ActionResult Index()
        {
            var movie = _dbContext.Movies.Include(m => m.Genre);

            return View(movie);

        }
        public ActionResult New()
        {
            var dbGenres = _dbContext.Genres.ToList();

            MovieViewModel movieViewModel = new MovieViewModel
            {
                Genres = dbGenres
            };

            return View("MovieForm", movieViewModel);
        }

        public ActionResult Edit(int id)
        {
            var dbMovie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            var movieViewModel = new MovieViewModel
            {
                Movie = dbMovie,
                Genres = _dbContext.Genres.ToList()
            };

            return View("MovieForm", movieViewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie Movie)
        {
            if (Movie.Id == 0)
            {
                _dbContext.Movies.Add(Movie);
            }
            else
            {
                var dbMovie = _dbContext.Movies.Single(m => m.Id == Movie.Id);

                dbMovie.Name = Movie.Name;
                dbMovie.NumberinStock = Movie.NumberinStock;
                dbMovie.ReleaseDate = Movie.ReleaseDate;
                dbMovie.DateAdded = Movie.DateAdded;
                dbMovie.GenreId = Movie.GenreId;
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Movie");

        }
        public ActionResult Details(int id)
        {
            var movie = _dbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            return View(movie);
        }
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Id = 1,
                Name = "Crown"

            };

            var customers = new List<Customer>
            {
                new Customer() { Id = 1 ,Name = "Ramesh"},
                new Customer() {Id=2,Name = "Sk"}

            };

            var randomviewModel = new RandomMovieViewControl()
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomviewModel);


        }
    }
}