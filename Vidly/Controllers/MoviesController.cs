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
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //exclui o objeto da memória
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: /Movies/random
        public ActionResult Random()
        {

         //return View(movie);
         //return Content("teste");
         //return HttpNotFound();
         // return new EmptyResult();
         //return RedirectToAction("Index","Home", new {index = 1, name = "teste"});

         var movie = new Movie() { Name= "The Godfather"};        
         var costumers = new List<Customer>
         {
            new Customer{Id = 1, name= "Roberto"},
            new Customer{Id = 2, name= "Pedro"},
            new Customer{Id = 3, name= "João"},
            new Customer{Id = 4, name= "Lucas"}
         };

         var viewModel = new RandowMovieViewModel
         {
            Movie = movie,
            Costumers = costumers
         };

         return View(viewModel);

        }

      public ActionResult edit(int id) {

         return Content("id=" + id);

      }


      public ActionResult Index() {

            //Eager loading - carrega os objetos relacionados ao objeto principal
            var movies = _context.Movies.Include(m => m.genre).ToList();
            // var customers = _context.Movies.Include(c => c.).ToList();
            if (!movies.Any())
                movies = null;
                
                                    
            return View(movies);


            }

      [Route("movies/released/{year}/{month:range(1,12)}")]
      public ActionResult ByReleaseDate(int year, int month)
      {
         return Content(year + "/" + month);
      }

        
    public ActionResult Customers() { 


            var customers = new List<Customer> {

                new Customer { name = "Customer 1",Id= 1},
                new Customer { name = "Customer 2",Id= 2},
                new Customer { name = "Customer 3",Id= 3}
            };
  
            return View(customers);
    }
        

        public ActionResult CustomerDetails(int id)
        {

            var customers = new List<Customer> {

                new Customer { name = "Customer 1",Id= 1},
                new Customer { name = "Customer 2",Id= 2},
                new Customer { name = "Customer 3",Id= 3}
            };

            
            return View(customers.Find(i => i.Id == id));
        }

        public ActionResult New()
        {
            var movieGenres = _context.Genres.ToList();
            var movieFormViewModel = new MovieFormViewModel
            {
                genres = movieGenres
            };

            return View("MovieForm",movieFormViewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
        
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Attach(movie);
                ctx.Entry(movie).State = EntityState.Added;  // or EntityState.Modified
                ctx.SaveChanges();
            }

            return RedirectToAction("Index","Movies");
        }


    }
}