using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.ViewModels
{
    public class CurrentBasket
    {
        public Basket Basket { get; set; }
        public BasketItem BasketItems { get; set; }
        public Product Products { get; set; }
    }
}
