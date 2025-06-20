using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Logistics.DAL;
using Logistics.DAL.EntityModels.Cargos;
using Logistics.Enums.Cargos;

namespace Logistics.Cargos
{
    public class PalletMover : IPalletMover
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
            RemovePreviousLocations(pallet);

            if (movingequest.PalletPlace.PlaceType == PlaceType.Grid)
            {
                var cells = await _logisticContext.Cells.FirstAsync(cell => cell.Id == movingequest.PalletPlace.PlaceId);                
                pallet.CellId = cells.Id;
            }
            else if(movingequest.PalletPlace.PlaceType == PlaceType.Trailer)
            {
                var trailer = await _logisticContext.Trailers.FirstAsync(trailer => trailer.Id == movingequest.PalletPlace.PlaceId);
                pallet.TrailerId = trailer.Id;
            }
            else if (movingequest.PalletPlace.PlaceType == PlaceType.Dock)
            {
                var dock = await _logisticContext.Docks.FirstAsync(dock => dock.Id == movingequest.PalletPlace.PlaceId);
                pallet.DockId = dock.Id;
            }

            await _logisticContext.SaveChangesAsync();
        }

        public async Task MovePalletsAsync(List<PalletMovingRequest> movingRequests)
        {
            CheckMovingRequests(movingRequests);            

            var palletIds = movingRequests.Select(request => request.PalletId).ToList();
            var pallets = await _logisticContext.Pallets
                .Where(pallet => palletIds.Contains(pallet.Id))
                .OrderBy(p => palletIds.IndexOf(p.Id))
                .ToListAsync();
            var placeType = movingRequests.First().PalletPlace.PlaceType;

            switch (placeType)
            {
                case PlaceType.Trailer:
                    await ProcessTrailerMove(movingRequests, pallets);
                    break;

                case PlaceType.Dock:
                    await ProcessDockMove(movingRequests, pallets);
                    break;

                case PlaceType.Grid:
                    await ProcessGridMove(movingRequests, pallets);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            await _logisticContext.SaveChangesAsync();
        }

        private async Task ProcessGridMove(List<PalletMovingRequest> movingRequests, List<PalletEntity> pallets)
        {
            var cellIds = movingRequests.Select(request => request.PalletPlace.PlaceId).ToList();
            var cells = await _logisticContext.Cells
                .Where(cell => cellIds.Contains(cell.Id))
                .ToDictionaryAsync(cell => cell.Id);

            var occupiedCells = await _logisticContext.Pallets
                .Where(pallet => cellIds.Contains(pallet.CellId ?? 0))
                .Select(pallet => pallet.CellId)
                .ToListAsync();

            if (occupiedCells.Any())
            {
                throw new InvalidOperationException($"Cells {string.Join(", ", occupiedCells)} are occupieed");
            }

            for (int i = 0; i < pallets.Count; i++)
            {
                RemovePreviousLocations(pallets[i]);
                pallets[i].CellId = movingRequests[i].PalletPlace.PlaceId;
            }
        }

        private async Task ProcessDockMove(List<PalletMovingRequest> movingRequests, List<PalletEntity> pallets)
        {
            var dockId = movingRequests.First().PalletPlace.PlaceId;
            var dock = await _logisticContext.Docks.FindAsync(dockId)
                ?? throw new KeyNotFoundException($"Trailer {dockId} did not found");

            foreach (var pallet in pallets)
            {
                RemovePreviousLocations(pallet);
                pallet.DockId = dockId;
            }
        }

        private async Task ProcessTrailerMove(List<PalletMovingRequest> movingRequests, List<PalletEntity> pallets)
        {
            var trailerId = movingRequests.First().PalletPlace.PlaceId;
            var trailer = await _logisticContext.Trailers.FindAsync(trailerId) ??
                throw new KeyNotFoundException($"Trailer {trailerId} did not found");

            foreach (var pallet in pallets)
            {
                RemovePreviousLocations(pallet);
                pallet.TrailerId = trailerId;
            }
        }

        private void CheckMovingRequests(List<PalletMovingRequest> palletMovingRequests)
        {
            if (palletMovingRequests.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(palletMovingRequests), "Moving requests list is empty or null");
            }

            var firstPlaceTypeParameter = palletMovingRequests.First().PalletPlace.PlaceType;
            var allRequestsDontHaveTheSamePlaceType = !palletMovingRequests.Any(palletMovingRequest => palletMovingRequest.PalletPlace.PlaceType != firstPlaceTypeParameter);

            if (allRequestsDontHaveTheSamePlaceType)
            {
                throw new ArgumentNullException(nameof(palletMovingRequests), "All pallets have to move in one place type");
            }

            foreach (var movingRequest in palletMovingRequests)
            {
                CheckMovingParameters(movingRequest);
            }
        }


        private void CheckMovingParameters(PalletMovingRequest movingRequest)
        {
            if (movingRequest == null)
            {
                throw new ArgumentNullException("Moving Request is null");
            }

            if (movingRequest.PalletId < MINIMUM_POSSIBLE_ID_VALUE)
            {
                throw new ArgumentException("Pallet id argument exeption");
            }

            if (movingRequest.PalletPlace == null || movingRequest.PalletPlace.PlaceId < MINIMUM_POSSIBLE_ID_VALUE)
            {
                throw new ArgumentException("Destination argument exeption");
            }
        }

        private void RemovePreviousLocations(PalletEntity pallet)
        {
            pallet.TrailerId = 0;
            pallet.DockId = 0;
            pallet.CellId = 0;
        }

        private const int MINIMUM_POSSIBLE_ID_VALUE = 1;
    }
}