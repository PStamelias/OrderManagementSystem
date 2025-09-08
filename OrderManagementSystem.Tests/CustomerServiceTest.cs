using Moq;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repository;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Tests
{
    public class CustomerServiceTest
    {
        [Fact]
        public async Task CreateCustomerAsync_WithEmptyCustomerDTO_ReturnException()
        {
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            var service = new CustomerService(mockCustomerRepo.Object);
            CustomerDTO customerDto = null;

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateCustomerAsync(customerDto));
            Assert.Equal("Value cannot be null. (Parameter 'Customer cannot be null')", ex.Message);

        }
        [Fact]
        public async Task CreateCustomerAsync_WithEmptyCustomerName_ReturnException()
        {
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            var service = new CustomerService(mockCustomerRepo.Object);
            var customerDto = new CustomerDTO
            {
                Name = "",
                Email = "Email"
            };

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateCustomerAsync(customerDto));
            Assert.Equal("Value cannot be null. (Parameter 'Customer Name cannot be null')", ex.Message);
        }
        [Fact]
        public async Task CreateCustomerAsync_WithEmptyCustomerEmail_ReturnException()
        {
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            var service = new CustomerService(mockCustomerRepo.Object);
            var customerDto = new CustomerDTO
            {
                Name = "Name",
                Email = ""
            };

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateCustomerAsync(customerDto));
            Assert.Equal("Value cannot be null. (Parameter 'Customer Email cannot be null')", ex.Message);
        }
        [Fact]
        public async Task CreateCustomerAsync_WithValidData_ExecutedOnce()
        {
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            var service = new CustomerService(mockCustomerRepo.Object);
            var customerDto = new CustomerDTO
            {
                Name = "Name",
                Email = "Email"
            };

            await service.CreateCustomerAsync(customerDto);
            mockCustomerRepo.Verify((r =>r.AddCustomer(It.Is<CustomerDTO>(p => p.Name==customerDto.Name && p.Email == customerDto.Email))), Times.Once);

        }
    }
}
