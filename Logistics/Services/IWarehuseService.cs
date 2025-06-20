using Logistics.DAL.EntityModels.Warehouses;

namespace Logistics.Services
{
    public interface IWarehuseService
    {
        Task<WarehouseEntity> GetWarehouseWithComponentsAndPalletsAsync(int id);

        Task<List<WarehouseEntity>> GetWarehousesAsync();
    }
}
