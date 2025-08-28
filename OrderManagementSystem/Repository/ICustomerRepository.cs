using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repository
{
    public interface ICustomerRepository
    {
        public  Task AddCustomer(CustomerDTO customerDTO);
        public  Task<Customer?> GetCustomer(Guid id);
    }
}
