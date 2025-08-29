using Moq;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repository;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Tests
{
    public class ProductServiceTest
    {
        [Fact]
        public async Task AddProduct_WithEmptyName_ThrowsArgumentNullException()
        {
            var mockProductRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockProductRepo.Object);

            var product = new ProductDTO
            {
                Name="",
                Price = 200
            };

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddProduct(product));
            Assert.Equal("Value cannot be null. (Parameter 'ProductName cannot be null')", ex.Message);

        }

        [Fact]
        public async Task AddProduct_WithEmptyPrice_ThrowsArgumentNullException()
        {
            var mockProductRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockProductRepo.Object);

            var product = new ProductDTO
            {
                Name = "Product",
                Price = 0
            };

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(()=> service.AddProduct(product));
            Assert.Equal("Value cannot be null. (Parameter 'ProductPrice cannot be null')",ex.Message);
        }

        [Fact]
        public async Task AddProduct_WithValidDTO_CallsRepoOnce()
        {
            var mockProductRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockProductRepo.Object);

            var product = new ProductDTO
            {
                Name = "Product",
                Price = 20
            };

            await service.AddProduct(product);

            mockProductRepo.Verify(r => r.AddProduct(It.Is<Product>(p => p.Name == product.Name && p.Price == product.Price)), Times.Once);
        }
    }
}
