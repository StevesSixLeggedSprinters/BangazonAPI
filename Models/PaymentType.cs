using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
   public class PaymentType //Rename PaymentType 
    {   
        [Key]
        public int PaymentTypeId {get; set;}

        [Required]
        public string AccountNumber {get; set;}
        
        [Required]
        public string PaymentTypeName {get; set;}

        [Required] 
        public int CustomerId {get; set;}

        public virtual Customer customer {get; set;}

    }
}