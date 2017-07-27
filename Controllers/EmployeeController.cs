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

    public class EmployeeController : Controller
    {
        private BangazonAPIContext _context;

        public EmployeeController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }


        //Get the api/values for the employee table
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> AllEmployees = from employee in _context.Employees select employee;

            if (AllEmployees == null)
            {

                return NotFound();
            }

            return Ok(AllEmployees);
        }

        //Get api/induvidualEmp/byID
       [HttpGet("{id}", Name="GetCustomer")]
       public IActionResult Get([FromRoute] int id)
       {
           if(!ModelState.IsValid)
           {
             BadRequest(ModelState);
           }
           try
           {
               Employee employee = _context.Employees.Single(e=>e.EmployeeId == id);
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
       [HttpPost]
       public IActionResult Post([FromBody] Employee employee)
       {
           if(!ModelState.IsValid)
           {
             BadRequest(ModelState);
           }
           _context.Employee.Add(employee);

           try
           {
            _context.SaveChanges();
           }
           catch(DbUpdateException)
           {
               if(EmployeeExists(employee.EmplpoyeeId))
               {
                   return new StatusCodeResult(StatusCodes.Status409Conflict);
               }
               else
               {
                   throw;
               }
           }
           return CreatedAtRoute(GetEmployee, new {id = employee.EmplpoyeeId}, employee);
       }
    }

}