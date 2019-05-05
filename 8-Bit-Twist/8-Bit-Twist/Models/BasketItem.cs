using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class BasketItem
    {
        public int ID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int BasketID { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Nav props
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [ForeignKey("BasketID")]
        public Basket Basket { get; set; }
    }
}
