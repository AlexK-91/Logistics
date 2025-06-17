using System.ComponentModel.DataAnnotations.Schema;
using Logistics.DAL.EntityModels.Cargos;
using Logistics.DAL.EntityModels.Transport;

namespace Logistics.DAL.EntityModels.Orders
{
    public class DeliveryOrderEntity : OrderEntity
    {
        public string PickupAddress { get; set; }

        public string DeliveryAddress { get; set; }

        public int TrailerId { get; set; }

        [ForeignKey("TrailerId")]
        public TrailerEntity Trailer { get; set; }

        public int CargoId { get; set; }

        [ForeignKey("CargoId")]
        public CargoEntity Cargo { get; set; }
    }
}
