﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class BasketItems
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        public int ApplicationUserID { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Nav props
        public Product Product { get; set; }
        public Basket Basket { get; set; }
    }
}
