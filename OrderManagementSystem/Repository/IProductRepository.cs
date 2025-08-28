using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repository
{
    public interface IProductRepository
    {
        public Task AddProduct(Product product);
        public Task<List<Product>> GetProductsAsync();
        public  Task<Product?> GetProductByID(Guid id);
    }
}
