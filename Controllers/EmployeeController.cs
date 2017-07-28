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

    /*KC - Created the Employee Controller
    This Controller is the GET all Employees Instances
    A Single GET Instance of an Employee
    POST to post new instance of Employee 
    PUT to change or update the instance of Employee */
    public class EmployeeController : Controller
    {
        private BangazonAPIContext _context;

        public EmployeeController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }


        //KC-GET for returning all instances of Employee if no data, it will return NotFound. 
        [HttpGet]
        public IActionResult Get()
        {
            //KC-Once the Department Resouce is created the following merge, This will change to have a .Include("Department")
            IQueryable<object> AllEmployees = from employee in _context.Employees select employee;

            if (AllEmployees == null)
            {

                return NotFound();
            }

            return Ok(AllEmployees);
        }

        //KC-Get api/induvidualEmp/byID
        //KC-Get an instance of Employee by the EmployeeId
       [HttpGet("{id}", Name="GetEmployee")]
       public IActionResult Get([FromRoute] int id)
       {
           if(!ModelState.IsValid)
           {
             BadRequest(ModelState);
           }
           try
           {
            //KC-Once the Department Resouce is created the following merge, This will change to have a .Include("Department")
               Employee employee = _context.Employees.Single(emp=>emp.EmployeeId == id);
               if (employee == null)
               {
                   return NotFound();
               }
               return Ok(employee);

           }
           catch(System.InvalidOperationException ex)
           {
               return NotFound();
           }
       }

       /* KC-POST is for adding a new instance of Employee to the database.
       If there is not EmployeeId for that instance it will add the new instance. 
       If that employee already exsist return an edit conflict that the instance already exsists.*/
       [HttpPost]
       public IActionResult Post([FromBody] Employee employee)
       {
           if(!ModelState.IsValid)
           {
             BadRequest(ModelState);
           }
           _context.Employees.Add(employee);

           try
           {
            _context.SaveChanges();
           }
           catch(DbUpdateException)
           {
               if(EmployeeExists(employee.EmployeeId))
               {
                   return new StatusCodeResult(StatusCodes.Status409Conflict);
               }
               else
               {
                   throw;
               }
           }
           return CreatedAtRoute("GetEmployee", new {id = employee.EmployeeId}, employee);
       }

       private bool EmployeeExists(int emplId)
       {
           return _context.Employees.Count(emp => emp.EmployeeId== emplId) > 0;
       }

       /*KC-PUT This is to edit or update and instance of employee.
       For a Put to be executed all key value pairs must be present in the Put request
       When a change from the put is successful a return value of 204 will return as successful. */
       [HttpPut("{id}")]
       public IActionResult Put(int id, [FromBody] Employee employee)
       {
           if(!ModelState.IsValid)
           {
               return BadRequest(ModelState);
           }
           if(id !=employee.EmployeeId)
           {
               return BadRequest();
           }

           _context.Entry(employee).State = EntityState.Modified;

           try
           {
               _context.SaveChanges();
           }
           catch(DbUpdateConcurrencyException)
           {
               if(!EmployeeExists(id))
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