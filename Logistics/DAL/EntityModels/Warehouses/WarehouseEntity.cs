using System.ComponentModel.DataAnnotations;

namespace Logistics.DAL.EntityModels.Warehouses
{
    public class WarehouseEntity
    {
        [Key]
        public int Id { get; set; } 

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public ICollection<DockEntity> Docks { get; set; }

        public ICollection<GridEntity> Grids { get; set; }
    }
}