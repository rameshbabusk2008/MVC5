using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;
 

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }
        //Get api/customers
        public IHttpActionResult GetCustomers()
        {

            var customerdto = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerdto);
        }

        //Get api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }


        //post api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto Customerdto)            
        {
            if (!ModelState.IsValid)
                return BadRequest();
                    
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(Customerdto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            Customerdto.Id = customer.Id;

            //return Customerdto;
            return Created(new Uri(Request.RequestUri + @"/" + customer.Id), Customerdto);
        }

        //put api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            Mapper.Map(customerdto, customerDb);

            //Mapper.Map<CustomerDto, Customer>(customerdto, customerDb);

            //customerDb.Name = customerdto.Name;
            //customerDb.BrithDate = customerdto.BrithDate;
            //customerDb.MembershipTypeId = customerdto.MembershipTypeId;
            //customerDb.IsSubscribedToNewsLetter = customerdto.IsSubscribedToNewsLetter;

            _context.SaveChanges();

            return Ok();
        }

        //delete api/customer/1
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            _context.Customers.Remove(customerDb);
            _context.SaveChanges();

            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}
