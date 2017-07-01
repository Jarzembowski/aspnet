using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Vidly.Models
{
   public class Customer
   {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        public string lastName { get; set; }
        public bool isSubscribedToNewsLetter { get; set; }
        public MembershipType membershipType { get; set; }    
        public byte membershipTypeid { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? birthDay { get; set; }

    }

   

}