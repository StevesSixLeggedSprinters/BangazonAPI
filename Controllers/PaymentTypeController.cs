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
    [Route("api/[controller]")]
    public class PaymentTypeController : Controller
    {
        private BangazonAPIContext _context;
        public PaymentTypeController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/values
        //This gets all the data
        [HttpGet]
        public IActionResult Get()
        {                      //
            IQueryable<object> AllPaymentTypes = from PaymentType in _context.PaymentType select PaymentType;

            if (AllPaymentTypes == null)
            {
                return NotFound();
            }

            return Ok(AllPaymentTypes);

        }

        // GET api/values/5
        // This is a hard coded example of retrieving the customer with a specific name 
        [HttpGet("{id}", Name="GetPayment")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try 
            {
                PaymentType paymentType = _context.PaymentType.Single(c => c.PaymentTypeId == id);
                if (paymentType == null)
                {
                    return NotFound();
                }
                
                return Ok(paymentType); 
            }
            catch(System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PaymentType.Add(paymentType);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentExists(paymentType.PaymentTypeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetPayment", new { id = paymentType.PaymentTypeId }, paymentType);
        }

        private bool PaymentExists(int payId)
        {
          return _context.PaymentType.Count(e => e.PaymentTypeId == payId) > 0;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentType.PaymentTypeId)
            {
                return BadRequest();
            }

            _context.Entry(paymentType).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        
/// Need to remove the Delete form this file eventually.!-- 
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PaymentType paymentType = _context.PaymentType.Single(m => m.PaymentTypeId == id);
            if (paymentType == null)
            {
                return NotFound();
            }

            _context.PaymentType.Remove(paymentType);
            _context.SaveChanges();

            return Ok(paymentType);
        }
    }
}
