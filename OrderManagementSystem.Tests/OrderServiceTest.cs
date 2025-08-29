using Castle.Core.Resource;
using Moq;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repository;
using OrderManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Tests
{
    public class OrderServiceTest
    {
        [Fact]
        public async Task CreateOrder_WithNonExistingCustomer_ReturnException()
        {
            var mockOrderRepo = new Mock<IOrderRepository>();
            var mockProductRepo = new Mock<IProductRepository>();
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            var service = new OrderService(mockOrderRepo.Object,mockProductRepo.Object,mockCustomerRepo.Object);
            var customerId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var order = new OrderDTO
            {
                CustomerId = customerId,
                ListProductIds = new List<Guid> { productId }
            };
            mockCustomerRepo.Setup(r => r.GetCustomer(customerId)).ReturnsAsync((Customer)null);
            mockProductRepo.Setup(r => r.GetProductByID(productId)).ReturnsAsync(new Product { Id=Guid.NewGuid(),Name="Name",Price=20});
            await Assert.ThrowsAsync<Exception>(() => service.CreateOrder(order));

        }
        [Fact]
        public async Task CreateOrder_WithNonExistingProduct_ReturnException()
        {
            var mockOrderRepo = new Mock<IOrderRepository>();
            var mockProductRepo = new Mock<IProductRepository>();
            var mockCustomerRepo = new Mock<ICustomerRepository>();
            var service = new OrderService(mockOrderRepo.Object, mockProductRepo.Object, mockCustomerRepo.Object);
            var customerId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var order = new OrderDTO
            {
                CustomerId = customerId,
                ListProductIds = new List<Guid> { Guid.NewGuid() }
            };
            mockCustomerRepo.Setup(r => r.GetCustomer(customerId)).ReturnsAsync(new Customer { Id=Guid.NewGuid(),Name="Name",Email="Email"});
            mockProductRepo.Setup(r => r.GetProductByID(productId)).ReturnsAsync((Product)null);


            await Assert.ThrowsAsync<Exception>(() => service.CreateOrder(order));
        }

       
        
    }
}
