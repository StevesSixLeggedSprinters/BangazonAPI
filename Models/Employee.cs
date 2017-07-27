using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
   public class Employee 
    {   
        [Key]
        public int EmplpoyeeId {get; set;}

        [Required]
        public string EmpFirstName {get; set;}
        
        [Required]
        public string EmpLastName {get; set;}
        
          
        [Required]
          
        public DateTime EmpStartDate { get; set; }

        public string EmpJobTitle {get; set; }



        // this is to set whether the customer is active/inactive
        [Required]
        public Boolean IsSupervisior { get; set; }

        //defaulting to false on IsSupervisior
        public Employee()
        {
            IsSupervisior = false;
        }
        ICollection<Employee> Employees;
    }
}