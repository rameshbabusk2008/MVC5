using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
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
                Customer = customers
            };

            return View(randomviewModel);
        }
    }
}