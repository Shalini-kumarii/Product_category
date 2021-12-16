using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pro_cat.Models
{
    public class IndexView
    {
        

        public Product ToRender { get; set; }
          public List<Category> ToProductTo { get; set; }
        public Association ProductForm { get; set; }
    }
}