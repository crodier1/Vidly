using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
//using System.Runtime.Caching;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;        

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Index()
        {
            //var ViewModel = new CustomerViewModel()
            //{
            //    Customers = _context.Customers.Include(c => c.MembershipType).ToList()
            //};

            //return View(ViewModel);

            //using memory ache to hold generes

            //if (MemoryCache.Default["Genres"] == null)
            //{
            //    MemoryCache.Default["Genres"] = _context.Genres.ToList();
            //}

            //var generes = (IEnumerable<Genre>) MemoryCache.Default["Genres"];


            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("CustomerList");
            }

            return View("ReadOnlyCustomerList");
        }

        public ActionResult ReadOnly(int id)
        {
            
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);


            if (customer == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = customer.Name;

            var ViewModel = new CustomerViewModel()
            {
                Customer = customer
            };

            return View(ViewModel);

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult NewCustomer()
        {
            ViewBag.Titile = "New Cusotmer";
            var ViewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };            

            return View("CustomerForm", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Title = "Please Retry";

                var ViewModel = new CustomerFormViewModel()
                { 
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", ViewModel);
            }

            if (customer.Id == 0)
            {
                //only add to membory not to db
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name;
                customerInDB.DateOfBirth = customer.DateOfBirth;
                customerInDB.IsSubScribedToNewsLetter = customer.IsSubScribedToNewsLetter;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
            }
            
            

            //update sql db
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult EditCustomer(int id)
        {            
            var cusomter = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (cusomter == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Title = "Edit Customer";

                var ViewModel = new CustomerFormViewModel()
                {
                    Customer = cusomter,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", ViewModel);
            }
            
        }


    }
}