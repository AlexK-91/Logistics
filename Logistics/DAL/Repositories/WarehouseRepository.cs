using Microsoft.EntityFrameworkCore;
using Logistics.DAL.EntityModels.Warehouses;
using AutoMapper;
using Logistics.Dto.Warehouses;

namespace Logistics.DAL.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly LogisticContext _logisticContext;
        private readonly IMapper _mapper;

        public WarehouseRepository(LogisticContext logisticContext, IMapper mapper)
        {
            _logisticContext = logisticContext;
            _mapper = mapper;
        }

        public async Task<Warehouse> GetWarehouseWithComponentsAndPalletsAsync(int id)
        {
            var warehouseEntity = await _logisticContext.Warehouses
                .Include(warehouse => warehouse.Docks)
                .Include(warehouse => warehouse.Grids)
                    .ThenInclude(grid => grid.Cells)
                        .ThenInclude(cell => cell.Pallet)
                .FirstAsync(warehouse => warehouse.Id == id);

            return _mapper.Map<Warehouse>(warehouseEntity);
        }

        public async Task<List<Warehouse>> GetWarehousesAsync()
        {
            var warehousesEntities = await _logisticContext.Warehouses.ToListAsync();
            return _mapper.Map<List<Warehouse>> (warehousesEntities); 
        }
    }
}
