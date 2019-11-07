using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FinalAssessment.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Order = new HashSet<Order>();
        }
        

        public int Cid { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage ="Names are required to be between 3 and 60 characters long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Required(ErrorMessage = "Please provide a Name")]
        public string Name { get; set; }

        [Range(16, 116, ErrorMessage = "Please enter a realistic age, (Between 16 and 116).")]
        [Required(ErrorMessage = "Please provide your age.")]
        public int Age { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
        [Required(ErrorMessage = "Please provide a phone number.")]
        public string Phone { get; set; }


        public virtual ICollection<Order> Order { get; set; }
    }
}
