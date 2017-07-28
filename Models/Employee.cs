using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    /*KC - Created the Employee Model, 
    This model sets the data structure of the Bangazon Inc. Employee data Structure
    The Primary Key is the EmployeeId
    The Required Keys are Employee First, Last Name, and the Empoyee StartDate. Which will be set at population of the object.
    The IsSupervisor will be a boolean which is false by default. 
    The Department Collection will be referenced as a Foreign Key
    */
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

        //Defaulting to false on IsSupervisior for every database entry.
        public Employee()
        {
            IsSupervisior = false;
        }
        
        //Setting a property of "Dept"  on the instance of emp
        public int DepartmentId {get; set;}
        //The below is where the foreign key to the Dept table will be related. 
        // This line below will need to be commented until the Deparment Table is accessible.
        public Department Department {get; set;}
    }
}