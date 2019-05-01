﻿using _8_Bit_Twist.Data;
using _8_Bit_Twist.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models
{
    public class InventoryService : IInventoryManager
    {
        private readonly _8BitDbContext _context;

        /// <summary>
        /// Creates a new InventoryService instance.
        /// </summary>
        /// <param name="context">The service's DbContext.</param>
        public InventoryService(_8BitDbContext context)
        {
            _context = context;
        }

        public Task AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all products in the current DbContext.
        /// </summary>
        /// <returns>A List of Products</returns>
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<Product> GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
