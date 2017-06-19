using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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


      public ActionResult Index(int? pageIndex, string sortBy) {

         if (!pageIndex.HasValue)
         {
            pageIndex = 1;
         }

         if (String.IsNullOrWhiteSpace(sortBy))
         {
            sortBy = "name";
         }

         return Content(String.Format("Pageindex={0}&SortBy={1}", pageIndex, sortBy));


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


        [Route("movies/customerdetails/{id}/{name}")]
        public ActionResult CustomerDetails(int id, string name)
        {
            return Content(String.Format("id = {0} - name = {1}" ,id,name));
        }



    }
}