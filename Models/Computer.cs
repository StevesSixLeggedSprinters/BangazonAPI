using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{

    //JACKIE created this Model for Computers
    //This class will set up a table for computers to be entered into the database.
    //This also references everything specified in the Computers Resource on our ERD.
   public class Computer 
    {   
        [Key]
        public int ComputerId {get; set;}

        public string PurchaseDate {get; set;}
        public string DecommissionDate {get; set;}
        public int EmployeeId {get; set;}

    }
}