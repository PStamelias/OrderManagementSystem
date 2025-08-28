namespace OrderManagementSystem.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<Guid> ListProductIds { get; set; }
        public DateTime OrderDate { get; set; }
        public int ΤotalAmount { get; set; }
    }
}
