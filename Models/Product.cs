using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    //JACKIE created this Product Model
    //This class will set up a model for Products that will be entered into the database.
    //This model references everything specified on our ERD for Products Resource.
   public class Product 
    {   

        //jk-Key is setting the ProductId as the Primary Key
        [Key]
        public int ProductId {get; set;}

        //jk-I'm requiring the ProductTypeId because ???
        [Required]
        public int ProductTypeId {get; set;}

        [Required]
        public DateTime DateProductAdded {get; set;}

        [Required]
        public int CustomerId {get; set;}

        public double Price {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public int ProductAmount {get; set;}

        //jk-This collection is telling the database that a product can be on many orders.
        //this code will not run until Order Controller and Model is set up
        //public virtual ICollection<Order> Orders {get; set;} 
        
    }
}