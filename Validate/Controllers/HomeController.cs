using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Validate.Models;

namespace Validate.Controllers
{
   public class HomeController : Controller
   {

      #region Register  

      //  
      // GET: /Home/Register  
      [AllowAnonymous]
      public ActionResult Register()
      {
         return View();
      }

      //  
      // POST: /Home/Register  
      [HttpPost]
      [AllowAnonymous]
      [ValidateAntiForgeryToken]
      public ActionResult Register(HomeViewModel model)
      {
       
         // Info.  
         return Content("OK");
       
      }

      #endregion
   }
}
