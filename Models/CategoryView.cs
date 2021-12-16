using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pro_cat.Models
{
    public class CategoryView
    {
        

        public Category RenderCategory { get; set; }
          public List<Product> ToGetCategory { get; set; }
        public Association CategoryForm { get; set; }
    }
}