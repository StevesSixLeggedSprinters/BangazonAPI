using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    //Kevin created this Department Model
    //This class will set up a model for Products that will be entered into the database.
    //This model references everything specified on our ERD for Products Resource.
   public class DeptType 
    {   
        //Setting the Key Name for Departments to DeptTypeId, value is an integer
        [Key]
        public int DeptTypeId {get; set;}

        //Requiring a Department Name to be entered to Access Departments
        [Required]
        public string DeptName {get; set;}
        
        //Set up a column to hold Expense Budget
        public string ExpBudget {get; set;}



    }
}