using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer Customer)
        {
            if (!ModelState.IsValid)
            {
                var CustomerViewModel = new CustomerViewModel
                {
                    Customer = Customer,
                    MembershipType = _context.MembershipType.ToList(),
                };

                return View("CustomerForm", CustomerViewModel);
            }
            if (Customer.Id == 0)
            {
                _context.Customers.Add(Customer);
            }
            else
            {
                var dbCustomer = _context.Customers.Single(c => c.Id == Customer.Id);
                //TryUpdateModel(dbCustomer,"", new string[] { "Name","BrithDate" });
                dbCustomer.Name = Customer.Name;
                dbCustomer.BrithDate = Customer.BrithDate;
                dbCustomer.MembershipTypeId = Customer.MembershipTypeId;
                dbCustomer.IsSubscribedToNewsLetter = Customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
           // }

            //return View(Customer);

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            var CustomerViewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList(),
            };

            return View("CustomerForm",CustomerViewModel);

        }

        public ActionResult New()
        {
            var MembershipType = _context.MembershipType.ToList();

            var CustomerViewModel = new CustomerViewModel
            {
                Customer = new Customer(),
                MembershipType = MembershipType
            };

            return View("CustomerForm",CustomerViewModel);
        }
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
;
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

    }
}