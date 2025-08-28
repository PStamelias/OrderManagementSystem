using OrderManagementSystem.Models;
using OrderManagementSystem.Repository;

namespace OrderManagementSystem.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) 
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateCustomerAsync(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
                throw new ArgumentNullException("Customer cannot be null");

            if (string.IsNullOrEmpty(customerDTO.Name))
                throw new ArgumentNullException("Customer Name cannot be null");

            if (string.IsNullOrEmpty(customerDTO.Email))
                throw new ArgumentNullException("Customer Email cannot be null");

            await _customerRepository.AddCustomer(customerDTO);
            

        }
    }
}
