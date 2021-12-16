using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pro_cat.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Field must be 3 characters or more")]
        [Display(Name = "Category Name:")]
        public string Name { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // public List<Dish> DishList { get; set; }
        public List<Association> CategoryProducts { get; set; }


    }
}