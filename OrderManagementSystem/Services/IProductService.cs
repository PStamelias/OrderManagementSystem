using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public interface IProductService
    {
        public Task AddProduct(ProductDTO productDTO);

        public Task<List<Product>> GetProducts();
    }
}
