using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public interface ICustomerService
    {
        public Task CreateCustomerAsync(CustomerDTO customerDTO);
    }
}
