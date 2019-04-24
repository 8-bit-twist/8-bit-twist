using _8_Bit_Twist.Data;
using _8_Bit_Twist.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class InventoryService : IInventoryManager
    {
        private readonly _8BitDbContext _context;

        public InventoryService(_8BitDbContext context)
        {
            _context = context;
        }

        public Task AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
