using MassTransit;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repository;

namespace OrderManagementSystem.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        public OrderService(IOrderRepository orderRepository,IProductRepository productRepository,ICustomerRepository customerRepository)
        { 
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }


        public async Task CreateOrder(OrderDTO orderDTO)
        {
            var listProducts = orderDTO.ListProductIds;
            var totalamount = 0;
            foreach (var productId in listProducts)
            {
                var product = await _productRepository.GetProductByID(productId);
                if (product == null)
                    throw new Exception("Order with id " + productId + " does not exists");
                totalamount += product.Price;
            }

            if ( await _customerRepository.GetCustomer(orderDTO.CustomerId)==null)
                throw new Exception("Customer with ID "+ orderDTO.CustomerId+" does not exist");

            var order = new Order
            {
                ΤotalAmount = totalamount,
                OrderDate = DateTime.Now,
                ListProductIds = listProducts,
                CustomerId = orderDTO.CustomerId,
                Id = Guid.NewGuid()
            };
            await _orderRepository.AddOrder(order);
        }
    }
}
