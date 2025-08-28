namespace OrderManagementSystem.Models
{
    public class OrderDTO
    {
        public Guid CustomerId { get; set; }
        public List<Guid> ListProductIds { get; set; }
    }
}
