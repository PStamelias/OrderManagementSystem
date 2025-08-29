using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public interface IOrderService
    {
        public  Task CreateOrder(OrderDTO orderDTO);
        public  Task<Order?> GetOrderById(Guid id);
    }
}
