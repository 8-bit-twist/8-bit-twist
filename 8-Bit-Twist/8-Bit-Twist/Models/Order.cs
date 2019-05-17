using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string ApplicationUserID { get; set; }

        [Required]
        [Display(Name = "Card Info")]
        public CCNumbers CardNumber { get; set; }

        [Required]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Zip { get; set; }

        public decimal TotalPrice { get; set; }
        public bool Completed { get; set; } = false;
        // Nav Properties
        public List<OrderItem> OrderItems { get; set; }

        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser User { get; set; }
    }

    public enum CCNumbers : long
    {
        Visa = 4007000000027,
        Mastercard = 5424000000000015,
        Discover = 6011000000000012
    }

}
