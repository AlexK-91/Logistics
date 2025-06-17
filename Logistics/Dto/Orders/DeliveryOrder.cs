namespace Logistics.Dto.Orders
{
    public class DeliveryOrder : Order
    {
        public required List<Cargo> Cargos { get; set; }
        public required string Location { get; set; } 
        public string Destination { get; set; } 
    }
}