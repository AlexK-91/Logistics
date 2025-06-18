using Logistics.Enums.Warehouses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistics.DAL.EntityModels.Warehouses
{
    public class DockEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        public WarehouseEntity Warehouse { get; set; }

        [Required]
        public DockStatus Status { get; set; }
    }
}
