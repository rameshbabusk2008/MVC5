﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
;
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

    }
}