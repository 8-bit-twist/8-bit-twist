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
        [Key]
        public int ID { get; set; }

        [Required]
        public string ApplicationUserID { get; set; }

        // Nav Properties
        public List<BasketItem> BasketItems { get; set; }

        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser User { get; set; }

    }
}
