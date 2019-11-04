using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalAssessment.Models
{
    public partial class Products
    {
        public Products()
        {
            Order = new HashSet<Order>();
        }

        public string Pid { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage ="Product names are required to be between 3 and 50 characters long.")]
        [Required(ErrorMessage = "A product name must be provided.")]
        public string ProductName { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage ="Product descriptions must be between 5 and 100 characters long.")]
        [Required(ErrorMessage = "Please provide a product desription.")]
        public string Description { get; set; }

        [DataType(DataType.Currency, ErrorMessage ="Please provide a valid price for the product.")]
        [Required(ErrorMessage = "Please provide a price for this product.")]
        public int? Price { get; set; }

        [Range(0, 10, ErrorMessage = "Please enter a number between 0 and 10.")]
        [Required(ErrorMessage = "Please enter a rating for the product.")]
        public int? Rating { get; set; }

        [StringLength(30, MinimumLength = 5, ErrorMessage ="Please enter a category for this product between 5 and 30 characters long.")]
        [Required(ErrorMessage = "Please enter a category for this product.")]
        public string Category { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
