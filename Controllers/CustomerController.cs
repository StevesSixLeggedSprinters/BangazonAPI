using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BangazonAPI.Controllers
{
    // kk - This controller will provide the methods GET, POST and PUT for the Customer table. 
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private BangazonAPIContext _context;
        public CustomerController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // kk - GET api/values
        //This gets all the Customer data from the database
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> AllCustomers = from customer in _context.Customer select customer;

            if (AllCustomers == null)
            {
                return NotFound();
            }

            return Ok(AllCustomers);

        }

        // kk - GET api/values/5
        // This is a hard coded example of retrieving the customer with a specific name. The Customer will be targeted by the id, but will also return the Customer's name.
        [HttpGet("{id}", Name="GetCustomer")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try 
            {
                Customer customer = _context.Customer.Single(c => c.CustomerId == id);
                if (customer == null)
                {
                    return NotFound();
                }
                
                return Ok(customer); 
            }
            catch(System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        // kk - POST api/values
        // This will post/add a new Customer to the database
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customer.Add(customer);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.CustomerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // kk - This method verifies whether or not a Customer exists. It tests this through a boolean, which evaluates if there is an int greater than zero.
        private bool CustomerExists(int custId)
        {
          return _context.Customer.Count(e => e.CustomerId == custId) > 0;
        }

        // kk - PUT api/values/
        // This method allows for a specific Customer to be modified.
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }
    }
}
