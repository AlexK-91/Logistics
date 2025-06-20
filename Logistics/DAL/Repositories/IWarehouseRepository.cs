using Logistics.DAL.EntityModels.Warehouses;
using Logistics.Dto.Warehouses;

namespace Logistics.DAL.Repositories
{
    public interface IWarehouseRepository
    {
        Task<Warehouse> GetWarehouseWithComponentsAndPalletsAsync(int id);

        Task<List<Warehouse>> GetWarehousesAsync();
    }
}