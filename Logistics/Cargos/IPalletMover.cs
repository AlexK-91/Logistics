namespace Logistics.Cargos
{
    public interface IPalletMover
    {
        Task MovePalletAsync(PalletMovingRequest movingequest);

        Task MovePalletsAsync(List<PalletMovingRequest> movingRequests);
    }
}
