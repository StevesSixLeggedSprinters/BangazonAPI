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
    //JACKIE created this Computer Controller
    //This controller will set up methods to GET, POST, PUT, & DELETE a computer

    [Route("api/[controller]")]
    public class ComputerController : Controller
    {
        private BangazonAPIContext _context;
        public ComputerController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/values
        //jk-This method will GET the entire list of computers that have been entered into the database
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> AllComputers = from computer in _context.Computers select computer;

            if (AllComputers == null)  
            {
                return NotFound();  //jk-If there are no computers entered into the database, an error (404) will be thrown
            }

            return Ok(AllComputers);  //jk-If there are no errors, return the entire list of computers

        }

        // GET api/values/5
        //jk-This method will GET a specific computer based on ID that has already been created in the database.
        [HttpGet("{id}", Name="GetComputer")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  //jk-If the state of the model is not set up correctly, this will return an error (400)
            }
            
            try 
            {
                Computer computer = _context.Computers.Single(x => x.ComputerId == id);  //jk-Here I am creating a new instance of computer that will grab a single element based on ID
                if (computer == null)
                {
                    return NotFound();  //jk-If there are no computers with that specific ID, this will throw an error (404) 
                }
                
                return Ok(computer); 
            }
            catch(System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/values
        //jk-This method will POST (add) a new computer to the table in the database
        [HttpPost]
        public IActionResult Post([FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  //jk-A (400) error will be returned if the computer model is not added correctly to the database
            }

            _context.Computers.Add(computer);
            
            try
            {
                _context.SaveChanges();  //jk-This will save all changes once a computer has been successfully added.
            }
            catch (DbUpdateException)
            {
                if (ComputerExists(computer.ComputerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);  //jk-If a computer with that specific ID already exists, return a conflict error (409)
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetComputer", new { id = computer.ComputerId }, computer);  //jk-If a computer is correctly added to the database return a 201 response that it was successfully created.
        }

        private bool ComputerExists(int compId)
        {
          return _context.Computers.Count(e => e.ComputerId == compId) > 0;  //jk-When a computer is added to the database, this will automatically start the ComputerID at 1 and increment from there with each new added computer.
        }

        // PUT api/values/5
        //jk-This method will PUT (edit) an existing computer in the database.
        //All key value pairs represented in the model must be present when updating the specific computer.
        //Errors will be thrown (400) if the model state is not complete with every key value pair.
        //Errors will be also be thrown if the computer's specific id is not added to the end of the url
        //Url must look like: http://localhost:5000/api/computer/{specificID}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Computer computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != computer.ComputerId)
            {
                return BadRequest();
            }

            _context.Entry(computer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();  //jk-Save all changes if data has be edited.
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(id))
                {
                    return NotFound();  //jk-If the computer doesn't exist in the database, an error will be thrown.
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // DELETE api/values/5
        //jk-This method will DELETE a specific computer in the database based on ID.
        //If all key value pairs, based on the computer model, are not present when clicking delete, an error will be thrown (400)
        //If the ID on the specific computer you want to delete does not match the ID it has in the database, an error will be thrown (404)
        //Once the computer is correctly deleted from the database, changes will be saved. 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Computer computer = _context.Computers.Single(m => m.ComputerId == id);
            if (computer == null)
            {
                return NotFound();
            }

            _context.Computers.Remove(computer);
            _context.SaveChanges();

            return Ok(computer);
        }
    }
}
