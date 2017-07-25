using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
   public class Customer 
    {   
        [Key]
        public int CustomerId {get; set;}

        [Required]
        public string FirstName {get; set;}
        
        [Required]
        public string LastName {get; set;}

        public string Email {get; set;}

        public string Phone {get; set;} 

        public string DateAccountCreated {get; set;}

        ICollection<Customer> Customers;
    }
}