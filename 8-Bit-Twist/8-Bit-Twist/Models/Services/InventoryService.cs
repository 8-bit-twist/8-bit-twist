using _8_Bit_Twist.Data;
using _8_Bit_Twist.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.Services
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

        /// <summary>
        /// Adds a new Product to the Database.
        /// </summary>
        /// <param name="product">New Product to add.</param>
        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a given Product.
        /// </summary>
        /// <param name="id">ID of Product to delete.</param>
        public async Task DeleteProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.ID == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all products in the current DbContext.
        /// </summary>
        /// <returns>A List of Products</returns>
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Gets a Product by its ID.
        /// </summary>
        /// <param name="id">The Product's ID.</param>
        /// <returns>A Product</returns>
        public async Task<Product> GetProductByID(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.ID == id);
            return product;
        }

        public Product GetProductByIDGreedy(int id)
        {
            return _context.Products.FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// Checks to see if a given Product by ID exists.
        /// </summary>
        /// <param name="id">ID to check for.</param>
        /// <returns>True if Product exists.</returns>
        public async Task<bool> ProductExists(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.ID == id);

            return product != null;
        }

        /// <summary>
        /// Updates Product info in the DB.
        /// </summary>
        /// <param name="id">ID of Product to update.</param>
        /// <param name="product">Product details for update.</param>
        public async Task UpdateProduct(int id, Product product)
        {
            if (id == product.ID)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
