using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _8_Bit_Twist.Models;
using _8_Bit_Twist.Models.Interfaces;
using _8_Bit_Twist.Models.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace _8_Bit_Twist.Pages.Admin
{
    [Authorize(Roles = ApplicationRoles.Admin)]
    public class ProductModel : PageModel
    {
        private readonly IInventoryManager _invManager;
        public Blob BlobImage { get; }

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        public ProductModel(IInventoryManager manager, IConfiguration configuration)
        {
            _invManager = manager;
            BlobImage = new Blob(configuration);
        }

        public async Task OnGet()
        {
            Product = await _invManager.GetProductByID(ID.GetValueOrDefault()) ?? new Product();
        }

        public async Task<IActionResult> OnPost()
        {
            Product existingProduct = await _invManager.GetProductByID(ID.GetValueOrDefault()) ?? new Product();

            //if (Product.ImgUrl == null)
            //{
            //    Product.ImgUrl = existingProduct.ImgUrl;
            //}
            //else
            //{
            //    var filePath = Path.GetTempFileName();

            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await Image.CopyToAsync(stream);
            //    }

            //    var container = await BlobImage.GetContainer("products");

            //    BlobImage.UploadFile(container, Image.FileName, filePath);

            //    CloudBlob blob = await BlobImage.GetBlob(Image.FileName, container.Name);

            //    Product.ImgUrl = blob.Uri.ToString();
            //}

            //existingProduct = Product;

            existingProduct.Name = Product.Name;
            existingProduct.Price = Product.Price;
            existingProduct.ReleaseDate = Product.ReleaseDate;

            await _invManager.UpdateProduct(ID.GetValueOrDefault(), existingProduct);
            return RedirectToPage("/Admin/Products/Manage");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _invManager.DeleteProduct(ID.GetValueOrDefault());
            return RedirectToPage("/Admin/Products/Index");
        }
    }
}