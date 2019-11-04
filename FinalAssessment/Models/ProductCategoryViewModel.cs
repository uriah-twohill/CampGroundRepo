using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssessment.Models
{
    public class ProductCategoryViewModel
    {
        public List<Products> Products { get; set; }
        public SelectList Catgories { get; set; }
        public string ProductCategory { get; set; }
        public string SearchString { get; set; }
    }
}
