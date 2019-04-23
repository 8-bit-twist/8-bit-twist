using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Data
{
    public class _8BitDbContext : DbContext
    {
        public _8BitDbContext(DbContextOptions<_8BitDbContext> options) : base(options)
        {

        }
    }
}
