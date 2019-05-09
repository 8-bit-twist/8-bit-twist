using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Computer { get; set; }

        public int BasketID { get; set; }

        [NotMapped]
        [ForeignKey("BasketID")]
        public Basket Basket { get; set; }

        [NotMapped]
        public List<Order> Orders { get; set; }
    }

    public static class ApplicationRoles
    {
        public const string Member = "Member";
        public const string Admin = "Admin";
    }
}
