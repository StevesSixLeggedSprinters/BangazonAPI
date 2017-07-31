using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    // kk - Customer class creates a table in the database to store...customers!
    // Customer class will contain a CustomerId [which is the Key]. The id will be generated when a new customer is POSTed to the db.
    // Customer class will hold the entities: FirstName(string), LastName(string), Email(string), Phone(string), DateAccountCreated(DateTime string), LastInteraction(DateTime string) and IsActive(see more in comments below)
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
        
        [Required]
        public DateTime DateAccountCreated {get; set;}
        
        
        // this is to determine the customer's last interaction  
        public DateTime LastInteraction { get; set; }

        // kk - this is to set whether the customer is active/inactive. Sql does not accept bool values, so the Customer method is created below to set a Customer's 'IsActive' value to an int, which is 1
        [Required]
        public int IsActive { get; set; }

        public Customer()
        {
            IsActive = 1;
            // PK get the current timestamp
            DateAccountCreated = DateTime.Now;
        }

        //PK I have changed this  Icollection customer to order to show the many orders in the collection.
        ICollection<Order> Orders;


        // This is to create a one to many relationship. A Customer will have many PaymentTypes
        public virtual ICollection<PaymentType> PaymentTypes {get; set;}

    }
}