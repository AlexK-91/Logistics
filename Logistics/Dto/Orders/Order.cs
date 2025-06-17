namespace Logistics.Dto.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public required Customer Customer { get; set; }
    }
}