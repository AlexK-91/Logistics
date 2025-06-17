using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}