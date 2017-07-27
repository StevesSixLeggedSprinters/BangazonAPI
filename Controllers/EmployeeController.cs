using System;
using System.Collections.Generic;
using System.Linq;
using BangazonAPI.Data;
using Microsoft.AspNetCore.Mvc;

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
        }


    }





}