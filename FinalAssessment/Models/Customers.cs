using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalAssessment.Models
{
    // Name of class Customers
    public partial class Customers
    {
        public Customers()
        {
            Order = new HashSet<Order>();
        }
        
        // Constructor for Customer ID (CId)
        public int Cid { get; set; }

        // Constructor and data validations for the string Name
        [StringLength(60, MinimumLength = 3, ErrorMessage ="Names are required to be between 3 and 60 characters long.")]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Please only use letters")]
        [Required(ErrorMessage = "Please provide a Name")]
        public string Name { get; set; }

        // Constructor and data validations for the int Age
        [Range(16, 116, ErrorMessage = "Please enter a realistic age.")]
        [Required(ErrorMessage = "Please provide your age.")]
        public int Age { get; set; }

        // Constructor and data validations for the string Phone number
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please only use numbers")]
        [Required(ErrorMessage = "Please provide a phone number.")]
        public string Phone { get; set; }


        public virtual ICollection<Order> Order { get; set; }
    }
}
