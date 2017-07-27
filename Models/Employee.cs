using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
   public class Employee 
    {   
        [Key]
        public int EmployeeId {get; set;}

        [Required]
        public string EmpFirstName {get; set;}
        
        [Required]
        public string EmpLastName {get; set;}
        
          
        [Required]
          
        public DateTime EmpStartDate { get; set; }

        public string EmpJobTitle {get; set; }



        //This will set the Supervisior boolean to False on default employees. 
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