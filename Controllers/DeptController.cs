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
    
    // Kevin created this Department Controller
    // The purpose of the Department Controller is to be able to GET, POST, and PUT.
    [Route("api/[controller]")]
    public class DeptTypeController : Controller
    {
        private BangazonAPIContext _context;
        public DeptTypeController(BangazonAPIContext ctx)
        {
            _context = ctx;
        }

        // GET api/DeptType
        //This (GET) returns all the Departments
        [HttpGet]
        public IActionResult Get()
        {                      
            IQueryable<object> AllDeptTypes = from DeptType in _context.DeptType select DeptType;

            if (AllDeptTypes == null)
            {
                return NotFound();
            }

            return Ok(AllDeptTypes);

        }

        // GET api/DeptType/1
        // This returns a specific Department Name
        [HttpGet("{id}", Name="GetDepartment")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try 
            {
                DeptType deptType = _context.DeptType.Single(c => c.DeptTypeId == id);
                if (deptType == null)
                {
                    return NotFound();
                }
                
                return Ok(deptType); 
            }
            catch(System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        // POST api/DeptType
        // This allows you to add a new Department
        [HttpPost]
        public IActionResult Post([FromBody] DeptType deptType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeptType.Add(deptType);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExist(deptType.DeptTypeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetDepartment", new { id = deptType.DeptTypeId }, deptType);
        }

        private bool DepartmentExist(int deptId)
        {
          return _context.DeptType.Count(e => e.DeptTypeId == deptId) > 0;
        }

        // PUT api/DeptType/1
        // This allows you to edit a specific Department
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DeptType deptType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deptType.DeptTypeId)
            {
                return BadRequest();
            }

            _context.Entry(deptType).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExist(id))
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
