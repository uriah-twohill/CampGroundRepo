using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssessment.Models
{
    // Constructor for Product category view model, used for searching by category of product
    public class ProductCategoryViewModel
    {
        // constructor for list of products named Products
        public List<Products> Products { get; set; }
        // constructor for SelectList called category
        public SelectList Catgories { get; set; }
        // constructor for string ProductCategory
        public string ProductCategory { get; set; }
        // constructor for string SearchString
        public string SearchString { get; set; }
    }
}
