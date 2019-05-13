using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class CreditCard
    {
        public CCNumbers CCNumber { get; set; }
    }

    public enum CCNumbers : long
    {
        Visa = 4007000000027,
        Mastercard = 5424000000000015,
        Discover = 6011000000000012
    }
}
