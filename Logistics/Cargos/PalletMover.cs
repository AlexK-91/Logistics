using Microsoft.EntityFrameworkCore;
using Logistics.DAL;
using Logistics.DAL.EntityModels.Cargos;
using Logistics.Enums.Cargos;

namespace Logistics.Cargos
{
    public class PalletMover
    {
        private readonly LogisticContext _logisticContext;

        public PalletMover(LogisticContext logisticContext)
        {
            _logisticContext = logisticContext;
        }

        public async Task MovePalletAsync(PalletMovingRequest movingequest)
        {
            CheckMovingParameters(movingequest);
            var pallet = await _logisticContext.Pallets
                .FirstAsync(pallet => pallet.Id == movingequest.PalletId);
            RemovePreviosLocations(pallet);

            if (movingequest.PalletPlace.CargoPlaceType == CargoPlaceType.Grid)
            {
                var cells = await _logisticContext.Cells.FirstAsync(cell => cell.Id == movingequest.PalletPlace.PlaceId);                
                pallet.CellId = cells.Id;
            }
            else if(movingequest.PalletPlace.CargoPlaceType == CargoPlaceType.Trailer)
            {
                var trailer = await _logisticContext.Trailers.FirstAsync(trailer => trailer.Id == movingequest.PalletPlace.PlaceId);
                pallet.TrailerId = trailer.Id;
            }
            else if (movingequest.PalletPlace.CargoPlaceType == CargoPlaceType.Dock)
            {
                var dock = await _logisticContext.Docks.FirstAsync(dock => dock.Id == movingequest.PalletPlace.PlaceId);
                pallet.DockId = dock.Id;
            }

            await _logisticContext.SaveChangesAsync();
        }

        public async Task MovePalletsAsync(List<PalletMovingRequest> movingRequests)
        {
            
        }

        private void CheckMovingParameters(PalletMovingRequest movingRequest)
        {
            if (movingRequest == null)
            {
                throw new ArgumentNullException("Moving Request is null");
            }

            if (movingRequest.PalletId < 1)
            {
                throw new ArgumentException("PalletId argument exeption");
            }
            
            if (movingRequest.PalletPlace == null || movingRequest.PalletPlace.PlaceId < 1)
            {
                throw new ArgumentException("Destination argument exeption");
            }
        }

        private void RemovePreviosLocations(PalletEntity pallet)
        {
            pallet.TrailerId = 0;
            pallet.DockId = 0;
            pallet.CellId = 0;
        }
    }
}