using Logistics.DAL.EntityModels.Warehouses;
using Logistics.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistics.DAL.EntityModels.Cargos
{
    public class PalletEntity : IIdentity
    {
        [Key]
        public int Id { get; set; }

        public int CargoId { get; set; }

        [Required]
        [ForeignKey("CargoId")]
        public CargoEntity Cargo { get; set; } 

        public int DockId { get; set; }

        [ForeignKey("DockId")]
        public DockEntity Dock { get; set; }

        public int CellId { get; set; }

        [ForeignKey("CellId")]
        public CellEntity Cell { get; set; }

        public int TrailerId { get; set; }

        [ForeignKey("TrailerId")]
        public Trailer Trailer { get; set; }
    }
}