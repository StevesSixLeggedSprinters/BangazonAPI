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
    public class ProductTypeController : Controller //Class name for the Product type controller
    {
        private BangazonAPIContext _context;
        
        public ProductTypeController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // kk - GET api/values
        // This will get ALL productType categories
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> AllProductTypes = from product_type in _context.ProductTypes select product_type; //verify that all of the 'product type' names are correct

            if (AllProductTypes == null)
            {
                return NotFound();
            }

            return Ok(AllProductTypes);
        }

        // kk - GET api/values/int(e.g. 1, 4, etc.)
        // This will retrieve individual ProductTypes by their id. It will output with their specific category name
        [HttpGet("{id}", Name="GetAllProductTypes")]

        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProductType product_type = _context.ProductTypes.Single(p => p.ProductTypeId == id);
                if (product_type == null)
                {
                    return NotFound();
                }

                return Ok(product_type);
            }
            catch(System.InvalidOperationException vex)
            {
                return NotFound();
            }
        }

        // kk POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ProductType product_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductTypes.Add(product_type);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductTypeExists(product_type.ProductTypeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetProductType", new { id = product_type.ProductTypeId }, product_type);
        }

        // kk - Verifies that a ProductType exists
        private bool ProductTypeExists(int prodTypeId)
        {
            return _context.ProductTypes.Count(p => p.ProductTypeId == prodTypeId) > 0;
        }

        
        // kk - PUT api/values 
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductType product_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != product_type.ProductTypeId)
            {
                return BadRequest();
            }
            _context.Entry(product_type).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
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
       
        // kk DELETE api/values
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductType product_type = _context.ProductTypes.Single(d => d.ProductTypeId == id);
            if (product_type == null)
            {
                return NotFound();
            }

            _context.ProductTypes.Remove(product_type);
            _context.SaveChanges();

            return Ok(product_type);
        }
    }
}

















