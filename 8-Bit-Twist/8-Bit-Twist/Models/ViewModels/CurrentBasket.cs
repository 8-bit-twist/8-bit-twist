using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.ViewModels
{
    public class CurrentBasket
    {
        public Basket Basket { get; set; }
        public ApplicationUser User { get; set; }
        public CreditCard CreditCards { get; set; }

        public decimal CurrentTotal { get; set; }
    }
}
