using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.ViewModels
{
    public class CheckoutViewModel
    {
        [Display(Name = "Shipping Address")]
        [Required]
        public string ShippingAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        [Display(Name = "Card Number")]
        public CCNumbers CardNumber { get; set; }
    }
}
