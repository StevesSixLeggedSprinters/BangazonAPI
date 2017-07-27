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
        public int PaytypeId {get; set;} 
           // public virtual PayType paytype { get; set; }


    [Required]
       public int DateOrderd {get; set;}
       public int customerId{get; set;}
      public virtual Customer customer { get; set; }


    
       
    
    }
}