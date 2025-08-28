using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repository
{
    public interface IOrderRepository
    {
        public Task AddOrder(Order order);
        public  Task<Order?> GetOrder(Guid id);
    }
}
