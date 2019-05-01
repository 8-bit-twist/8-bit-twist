using _8_Bit_Twist.Models;
using System;
using Xunit;

namespace _8_Bit_TwistTests
{
    public class ProductModelTests
    {
        [Fact]
        public void CanGetID()
        {
            Product product = new Product() { ID = 1 };

            Assert.Equal(1, product.ID);
        }

        [Fact]
        public void CanSetID()
        {
            Product product = new Product() { ID = 1 };

            product.ID = 2;

            Assert.Equal(2, product.ID);
        }

        [Fact]
        public void CanGetSKU()
        {
            Product product = new Product() { SKU = "1" };

            Assert.Equal("1", product.SKU);
        }

        [Fact]
        public void CanSetSKU()
        {
            Product product = new Product() { SKU = "1" };

            product.SKU = "2";

            Assert.Equal("2", product.SKU);
        }

        [Fact]
        public void CanGetPrice()
        {
            Product product = new Product() { Price = 1.00m };

            Assert.Equal(1.00m, product.Price);
        }

        [Fact]
        public void CanSetPrice()
        {
            Product product = new Product() { Price = 1.00m };

            product.Price = 1.50m;

            Assert.Equal(1.50m, product.Price);
        }

        [Fact]
        public void CanGetDescription()
        {
            Product product = new Product() { Description = "test" };

            Assert.Equal("test", product.Description);
        }

        [Fact]
        public void CanSetDescription()
        {
            Product product = new Product() { Description = "test one" };

            product.Description = "test two";

            Assert.Equal("test two", product.Description);
        }

        [Fact]
        public void CanGetImgUrl()
        {
            Product product = new Product() { ImgUrl = "test.jpg" };

            Assert.Equal("test.jpg", product.ImgUrl);
        }

        [Fact]
        public void CanSetImgUrl()
        {
            Product product = new Product() { ImgUrl = "test.jpg" };

            product.ImgUrl = "test.png";

            Assert.Equal("test.png", product.ImgUrl);
        }

        [Fact]
        public void CanGetGeneration()
        {
            Product product = new Product() { Generation = Generations.One };

            Assert.Equal(Generations.One, product.Generation);
        }

        [Fact]
        public void CanSetImgGeneration()
        {
            Product product = new Product() { Generation = Generations.One };

            product.Generation = Generations.Two;

            Assert.Equal(Generations.Two, product.Generation);
        }

        [Fact]
        public void CanGetReleaseDate()
        {
            Product product = new Product() { ReleaseDate = "April 1" };

            Assert.Equal("April 1", product.ReleaseDate);
        }

        [Fact]
        public void CanSetReleaseDate()
        {
            Product product = new Product() { ReleaseDate = "April 1" };

            product.ReleaseDate = "May 1";

            Assert.Equal("May 1", product.ReleaseDate);
        }

    }
}
