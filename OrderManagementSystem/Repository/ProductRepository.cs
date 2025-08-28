using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Models;
using System.ComponentModel;

namespace OrderManagementSystem.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext   context) 
        {
            _context = context;
        }


        public async Task AddProduct(Product product)
        {
           
            await using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.AddRange(product);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
           
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByID(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
