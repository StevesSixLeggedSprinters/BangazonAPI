using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{

    // PK It is creating instance of order
   public class Order 
    {   
        //PK This is primary key
        [Key]
        public int OrderId {get; set;}

//PK It is foreign key and required
     [Required] 
        public int PaytypeId {get; set;} 
           // public virtual PayType paytype { get; set; }


    [Required]// PK It is required
       public DateTime DateOrdered {get; set;}//PK This specify Date and Time
       public int customerId{get; set;}//PK  This is foreign key from customer table
      public virtual Customer customer { get; set; }


    
       
    
    }
}