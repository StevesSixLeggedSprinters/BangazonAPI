using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangazonAPI.Models
{
    // kk-ProductType class will store Category Names and will be a FK for products
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }

        [Required]
        public string CategoryName { get; set; }
       
        // kk - There can be many products in a ProductType category. Querying Products will return the ProductType. 
        public virtual ICollection<Product> Products { get; set; }

    }
}