using Logistics.Dto.Warehouses;

namespace Logistics.Dto.Orders
{
    public class StorageOrder : Order
    {
        public required Cargo Cargo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }         
        public Warehouse? Warehouse { get; set; }
    }
}