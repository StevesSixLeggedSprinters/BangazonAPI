using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
   public class Order 
    {   
        [Key]
        public int OrderId {get; set;}

        [Required]
        public string FirstName {get; set;}
        
        [Required]
        public string LastName {get; set;}

        public string Email {get; set;} // verify whether or not we need email

        public string Phone {get; set;} // verify whether or not we need phone
        
        [Required]
        public DateTime DateAccountCreated {get; set;} //check to see if 'string' needs to be replaced with 'DateTime'
        
        [Required]
        // this is to determine the customer's last interaction  
        public DateTime LastInteraction { get; set; }

        // this is to set whether the customer is active/inactive
        [Required]
        public int IsActive { get; set; }

        public Order()
        {
            IsActive = 1;
        }
        ICollection<Order> Orders;
    }
}