using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class Basket
    {
        public int ID { get; set; }

        [Required]
        public string ApplicationUserID { get; set; }

        // Nav props
        [ForeignKey("ApplicationUserID")]
        public ApplicationUser User { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
