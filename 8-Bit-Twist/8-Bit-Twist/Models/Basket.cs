using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class Basket
    {
        public int ID { get; set; }

        [Required]
        public int ApplicationUserID { get; set; }

        // Nav props
        public ApplicationUser User { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
