using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImgUrl { get; set; }

        [Required]
        public Generations Generation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string ReleaseDate { get; set; }
    }

    public enum Generations
    {
        One,
        Two,
        Three
    }
}
