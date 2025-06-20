using Logistics.DAL.EntityModels;
using Logistics.Enums.Warehouses;

namespace Logistics.Dto.Warehouses
{
    public class Dock : IIdentity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public DockStatus Status { get; set; }

        public Trailer Trailer { get; set; }
    }
}
