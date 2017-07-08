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
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;


        //inicializa no construtor - atalho ctor
        public CustomerController()
        {
            _context = new ApplicationDbContext();

        }

        //exclui o objeto da memória
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            //Eager loading - carrega os objetos relacionados ao objeto principal
            var customers = _context.Customers.Include(c => c.membershipType).ToList();

            return View(customers);
        }
        
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.membershipType).ToList().Find(i => i.Id == id);         
            return View(customer);
          
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                membershipTypes = membershipTypes
            };           
  
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerDB.name = customer.name;
                customerDB.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
                customerDB.birthDay = customer.birthDay;
                customerDB.membershipTypeid = customer.membershipTypeid;
            }

            _context.SaveChanges();


            return RedirectToAction("Index","Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) 
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                customer = customer,
                membershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);

        }

           

    }
}
