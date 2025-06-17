using Logistics.DAL.EntityModels;

namespace Logistics.Dto.Warehouses
{
    public class Grid : IIdentity
    {
        public int Id { get; set; }
        public List<Cell> Cells { get; set; } = new List<Cell>();
    }
}