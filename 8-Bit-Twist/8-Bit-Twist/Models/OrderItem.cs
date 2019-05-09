using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class OrderItem
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        // Nav props
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [ForeignKey("OrderID")]
        public Order Order { get; set; }
    }
}
