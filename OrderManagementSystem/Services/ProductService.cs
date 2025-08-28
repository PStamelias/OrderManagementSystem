using OrderManagementSystem.Models;
using OrderManagementSystem.Repository;

namespace OrderManagementSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            if (string.IsNullOrEmpty(productDTO.Name))
                throw new ArgumentNullException("ProductName cannot be null");

            if (productDTO.Price == 0)
                throw new ArgumentNullException("ProductPrice cannot be null");

            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = productDTO.Name,
                Price = productDTO.Price,
            };
            await _productRepository.AddProduct(product);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
