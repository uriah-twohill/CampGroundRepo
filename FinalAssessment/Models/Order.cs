using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalAssessment.Models
{
    public partial class Order
    {
        public int Oid { get; set; }

        [Required(ErrorMessage = "Please select a Customer ID for this order.")]
        public int Cid { get; set; }

        [Required(ErrorMessage ="Please select a Product ID for this order.")]
        public string Pid { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date, ErrorMessage ="Please enter a purchase date for this order.")]
        [CurrentDate(ErrorMessage ="Date must be equal to of before todays date.")]
        [Required(ErrorMessage = "Please enter a purchase date for this order.")]
        public DateTime PurchaseDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Please enter a payment date for this order.")]
        [CurrentDate(ErrorMessage = "Date must be equal to of before todays date.")]
        [Required(ErrorMessage = "Please enter a payment date for this order.")]
        public DateTime PaymentDate { get; set; }

        public virtual Customers C { get; set; }
        public virtual Products P { get; set; }
    }
}
