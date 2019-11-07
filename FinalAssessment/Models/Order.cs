using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalAssessment.Models
{
    // name of class Order
    public partial class Order
    {
        // constructor for Order ID (Oid)
        public int Oid { get; set; }

        // Constructor and data validations for the int Cid
        [Required(ErrorMessage = "Please select a Customer ID for this order.")]
        public int Cid { get; set; }

        // Constructor and data validations for the string Pid
        [Required(ErrorMessage ="Please select a Product ID for this order.")]
        public string Pid { get; set; }

        // Constructor and data validations for the datetime PurchaseDate
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date, ErrorMessage ="Please enter a purchase date for this order.")]
        [CurrentDate(ErrorMessage ="Date must be equal to of before todays date.")]
        [Required(ErrorMessage = "Please enter a purchase date for this order.")]
        public DateTime PurchaseDate { get; set; }

        // Constructor and data validations for the datetime PurchaseDate
        [DataType(DataType.Date, ErrorMessage = "Please enter a payment date for this order.")]
        [CurrentDate(ErrorMessage = "Date must be equal to of before todays date.")]
        [Required(ErrorMessage = "Please enter a payment date for this order.")]
        public DateTime PaymentDate { get; set; }

        // public virtural costructor for C (of type Customer)
        public virtual Customers C { get; set; }
        // public virtural costructor for C (of type Customer)
        public virtual Products P { get; set; }
    }
}
