using Logistics.DAL.EntityModels;

namespace Logistics.Dto.Warehouses
{
    public class Cell : IIdentity
    {
        public int Id { get; set; }
        public int ColumnNumber { get; set; }
        public int RowNumber { get; set; }
        public Pallet? Pallet { get; set; }
    }
}