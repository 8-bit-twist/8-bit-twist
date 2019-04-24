using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Bit_Twist.Models.Interfaces
{
    interface IInventoryManager
    {


        // Get a single product by ID
        Task<Product> GetProductByID(int id);

        // Get a list of all products
        Task<List<Product>> GetAllProducts();

        // Add a product to the DB
        Task AddProduct(Product product);

        // Update info for a product
        Task UpdateProduct(Product product);

        // Delete a product
        void DeleteProduct(Product product);

        // Check if a product exists by ID
        bool ProductExists(int id);
    }
}
