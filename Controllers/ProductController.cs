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
    //JACKIE created this ProductController
    //This controller's purpose is to be able to GET, POST, PUT, & DELETE

    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private BangazonAPIContext _context;
        public ProductController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        //jk-this will retrieve all the product data
        [HttpGet]
        public IActionResult Get()
        {
            //jk-Once an Order Controller and Model are set up, would like to change this next line of code to:
            //IQueryable<object> AllProducts = _context.Products.Include("Orders");
            IQueryable<object> AllProducts = from product in _context.Products select product;

            if (AllProducts == null)
            {
                return NotFound();
            }

            return Ok(AllProducts);

        }

        //jk-this will retrieve a single product with a specific name
        [HttpGet("{id}", Name="GetProduct")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try 
            {
                Product product = _context.Products.Single(p => p.ProductId == id);
                if (product == null)
                {
                    return NotFound();
                }
                
                return Ok(product); 
            }
            catch(System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        //jk-this will add a new product to the database
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Products.Add(product);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.ProductId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetProduct", new { id = product.ProductId }, product);
        }

        private bool ProductExists(int prodId)
        {
          return _context.Products.Count(e => e.ProductId == prodId) > 0;
        }

        //jk-this will "edit" an individual product
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        //jk-this will delete an individual product from the database
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = _context.Products.Single(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }
    }
}