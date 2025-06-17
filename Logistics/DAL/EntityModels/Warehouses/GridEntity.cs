using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistics.DAL.EntityModels.Warehouses
{
    public class GridEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public List<CellEntity> Cells { get; set; }

        [Required]
        public int WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        public WarehouseEntity Warehouse { get; set; }
    }
}