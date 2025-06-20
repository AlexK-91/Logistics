using Logistics.DAL.Repositories;
using Logistics.Dto.Warehouses;

namespace Logistics.Services
{
    public class WarehouseService : IWarehouseRepository
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<Warehouse> GetWarehouseWithComponentsAndPalletsAsync(int id)
        {
            return await _warehouseRepository.GetWarehouseWithComponentsAndPalletsAsync(id);
        }

        public async Task<List<Warehouse>> GetWarehousesAsync()
        {
            return await _warehouseRepository.GetWarehousesAsync();
        }
    }
}