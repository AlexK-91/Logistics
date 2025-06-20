using Microsoft.EntityFrameworkCore;
using Logistics.DAL.EntityModels.Warehouses;

namespace Logistics.DAL.Repositories
{
    public class GridRepository
    {
        private readonly LogisticContext _logisticContext;

        public GridRepository(LogisticContext logisticContext)
        {
            _logisticContext = logisticContext;
        }

        public async Task<GridEntity> GetGridWithPalletsAsync(int id)
        {
            return await _logisticContext.Grids
                .Include(grid => grid.Cells)
                    .ThenInclude(cell => cell.Pallet)
                .FirstAsync(grid => grid.Id == id);
        }

        public async Task<List<GridEntity>> GetGridsAsync(int warehouseId)
        {
            return await _logisticContext.Grids.Where(grid => grid.WarehouseId == warehouseId).ToListAsync();
        }
    }
}
