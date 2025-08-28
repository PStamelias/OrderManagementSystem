using OrderManagementSystem.Models;
using System.Reflection.Metadata.Ecma335;

namespace OrderManagementSystem.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddOrder(Order order)
        {

            await using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.AddRange(order);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<Order?> GetOrder(Guid id)
        {
            var order= await _context.Orders.FindAsync(id);
            return order != null ? order : null;
        }
    }
}
