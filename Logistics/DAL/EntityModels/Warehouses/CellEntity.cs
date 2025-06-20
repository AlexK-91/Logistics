using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Logistics.DAL.EntityModels.Cargos;

namespace Logistics.DAL.EntityModels.Warehouses
{
    public class CellEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int ColumnNumber { get; set; }

        [Required]
        public int RowNumber { get; set; }

        public int GridId { get; set; }

        [ForeignKey("GridId")]
        public GridEntity Grid { get; set; }

        public int? PalletId { get; set; }

        [ForeignKey("PalletId")]
        public PalletEntity? Pallet { get; set; }
    }
}