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
    // Class name for the TrainingProgram controller
    // This controller contains POST, PUT, GET, and DELETE methods.
    [Route("api/[controller]")]
    public class TrainingProgramController : Controller
    {
        private BangazonAPIContext _context;
        public TrainingProgramController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // kk - GET api/values
        // This will query all the training programs. 
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> AllTrainingPrograms = from training_program in _context.TrainingPrograms select training_program;

            if (AllTrainingPrograms == null)
            {
            return NotFound();
            }

            return Ok(AllTrainingPrograms);
        }

        // kk - GET api/values/int(e.g. 1, 4, etc.)
        // This will retrieve an individual Training program by its id.
        [HttpGet("{id}", Name="GetTrainingProgram")]

        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                TrainingProgram training_program = _context.TrainingPrograms.Single(p => p.TrainingProgramId == id);
                if (training_program == null)
                {
                return NotFound();
                }

                return Ok(training_program);
            }
            catch(System.InvalidOperationException vex)
            {
            return NotFound();
            }
        }

        // kk - POST api/values
        // this method creates a new TrainingProgram in the DB.
        // The TrainingProgramName is the only entity that needs to be added when posting a new object to the db through Postman. The TrainingProgramId will be generated automatically upon posting.
        [HttpPost]
        public IActionResult Post([FromBody] TrainingProgram training_program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrainingPrograms.Add(training_program);

            try
            {
            _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrainingProgramExists(training_program.TrainingProgramId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTrainingProgram", new { id = training_program.TrainingProgramId }, training_program);
            }

            // kk - This method verifies that a TrainingProgram exists
            private bool TrainingProgramExists(int trainProgId)
            {
            return _context.TrainingPrograms.Count(p => p.TrainingProgramId == trainProgId) > 0;
            }

            // kk - PUT api/values
            // This method will modify the TrainingProgram object in the database.
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] TrainingProgram training_program)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != training_program.TrainingProgramId)
                {
                    return BadRequest();
                }

                _context.Entry(training_program).State = EntityState.Modified;
                
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingProgramExists(id))
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
        // this method will remove a training program from the database
        // The TrainingProgramId will be targeted. This will remove the entire object with all it's properties
        // A TrainingProgram can only be DELETED if the StartDate is in the future
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TrainingProgram training_program = _context.TrainingPrograms.Single(d => d.TrainingProgramId == id);
            
            // This was the first attempt at comparing dates
            if (training_program.StartDate < DateTime.Today)
            {
                return BadRequest(ModelState);
            }
            if (training_program == null)
            {
                return NotFound();
            }
            
                _context.TrainingPrograms.Remove(training_program);
                _context.SaveChanges();

                return Ok(training_program);
        }
    }
}