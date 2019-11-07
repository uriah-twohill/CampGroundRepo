using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalAssessment.Models
{
    // name of class Products
    public partial class Products
    {
        public Products()
        {
            Order = new HashSet<Order>();
        }

        // constructor and data validations for string Product ID (Pid)
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please only use numbers")]
        public string Pid { get; set; }

        // constructor and data validations for string ProductName
        [StringLength(60, MinimumLength = 3, ErrorMessage ="Product names are required to be between 3 and 50 characters long.")]
        [Required(ErrorMessage = "A product name must be provided.")]
        public string ProductName { get; set; }

        // constructor and data validations for string Description
        [StringLength(100, MinimumLength = 5, ErrorMessage ="Product descriptions must be between 5 and 100 characters long.")]
        [Required(ErrorMessage = "Please provide a product desription.")]
        public string Description { get; set; }

        // constructor and data validations for int Price
        [DataType(DataType.Currency, ErrorMessage ="Please provide a valid price for the product.")]
        [Required(ErrorMessage = "Please provide a price for this product.")]
        public int? Price { get; set; }

        // constructor and data validations for int Rating
        [Range(0, 10, ErrorMessage = "Please enter a number between 0 and 10.")]
        [Required(ErrorMessage = "Please enter a rating for the product.")]
        public int? Rating { get; set; }

        // constructor and data validations for string Category
        [StringLength(30, MinimumLength = 5, ErrorMessage ="Please enter a category for this product between 5 and 30 characters long.")]
        [RegularExpression("^[A-Za-z ]*$", ErrorMessage = "Please only use letters")]
        [Required(ErrorMessage = "Please enter a category for this product.")]
        public string Category { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
