using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
     //Kevin created this Payment Type Model
     //This class will set up a model for Payment Types that will be entered into the database.
     //This model references everything specified on our ERD for Payment Type Resource.
   public class PaymentType 
    {   
        //Setting the Key Name for Payment Types to PaymentTypeId, value is an integer
        [Key]
        public int PaymentTypeId {get; set;}

        //Requiring an Account Number to be entered 
        [Required]
        public string AccountNumber {get; set;}
        
        //Requiring a Payment Type Name

        [Required]
        public string PaymentTypeName {get; set;}

        //Requiring a Customer Id
        [Required] 
        public int CustomerId {get; set;}

        //Making Customer id available to the Payment Type resource
        public virtual Customer customer {get; set;}

    }
}