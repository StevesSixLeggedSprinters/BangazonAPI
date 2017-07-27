using System.Linq;
using BangazonAPI.Data;
using BangazonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace BangazonAPI.Controllers

{// 
    [Route("api/[controller]")]
    //PK- Created this Controller to get, post, add, delete the Orders


    public class OrderController : Controller
    {
        private BangazonAPIContext _context;
        public OrderController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        //PK  GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> AllOrders = from order in _context.Orders select order;

            if (AllOrders == null)
            {
                return NotFound();
            }

            return Ok(AllOrders);

        }

        //PK GET api/values/5
        //PK This gets all the data. Get an item by ID	
        // PK This is a hard coded example of retrieving the order with a specific name. 
        [HttpGet("{id}", Name="GetOrder")]
        public IActionResult Get([FromRoute] int id)
        {
            //PK if order is null return notFound
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try 
            {
                Order order = _context.Orders.Single(o => o.OrderId == id);
                if (order == null)
                {
                    return NotFound();
                }
                
                return Ok(order); 
            }
            catch(System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // PK POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders.Add(order);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.OrderId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            int orderId =order.OrderId;
            return NewMethod(order, orderId);
        }

        private CreatedAtRouteResult NewMethod(Order order, int orderId)
        {
            return base.CreatedAtRoute("GetOrder", new { id = orderId }, GetOrder1(order));
        }

        private static Order GetOrder1(Order order)
        {
            return order;
        }

        private bool OrderExists(int custId)
        {
          return _context.Orders.Count(e => e.OrderId == custId) > 0;
        }

        private object GetOrder()
        {
            return _context.Order;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id !=order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

            Order order = _context.Orders.Single(c => c.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            GetOrders().Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }

        private DbSet<Order> GetOrders()
        {
            return
                        _context.Orders;
        }
    }
}
