using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomer(CustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                Id= Guid.NewGuid(),
                Email = customerDTO.Email,
                Name = customerDTO.Name,
            };
            await using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.AddRange(customer);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }


        public async Task<Customer?> GetCustomer(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

    }
}
