using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
   public class Movie
   {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime releaseDate { get; set; }
        public Genre genre { get; set; }        
        public int numberInStock { get; set; }




    }

}
