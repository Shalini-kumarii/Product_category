
   
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pro_cat.Models
{
    public class Association 
    {
        [Key]
        public int AssociationId { get; set; }

        // Foreign Key and Navigation Property for the Product
        [Required]
        public int ProductId { get; set; }
        public Product AllProduct { get; set; }

        // Foreign Key and Navigation Property for the Category
        [Required]
        public int CategoryId { get; set; }
        public Category AllCategory { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;   
     
       
}
}