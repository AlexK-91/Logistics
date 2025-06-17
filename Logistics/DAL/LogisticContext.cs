using Microsoft.EntityFrameworkCore;
using Logistics.DAL.EntityModels.Cargos;
using Logistics.DAL.EntityModels.Orders;
using Logistics.DAL.EntityModels.Warehouses;
using Logistics.DAL.EntityModels.Transport;
using Logistics.DAL.EntityModels.Customers;

namespace Logistics.DAL
{
    public class LogisticContext : DbContext
    {
        public LogisticContext(DbContextOptions options) : base(options)
        {
        }
        
        protected LogisticContext()
        {
        }

        #region Cargos
        public DbSet<CargoEntity> Cargos { get; set; }

        public DbSet<PalletEntity> Pallets { get; set; }
        #endregion

        #region Orders
        public DbSet<DeconsolidationOrderEntity> DeconsolidationOrders { get; set; }

        public DbSet <DeliveryOrderEntity> DeliveryOrders { get; set; }

        public DbSet<StorageOrderEntity> StorageOrders { get; set; }
        #endregion

        #region Warehouses
        public DbSet<WarehouseEntity> Warehouses { get; set; }

        public DbSet<DockEntity> Docks { get; set; }

        public DbSet<GridEntity> Grids { get; set; }

        public DbSet<CellEntity> Cells {  get; set; }
        #endregion

        #region Transports
        public DbSet<TrailerEntity> Trailers { get; set; }

        public DbSet<TruckEntity> Trucks { get; set; }
        #endregion

        #region Customers
        public DbSet<CustomerEntity> Customers { get; set; }

        public DbSet<DiscountEntity> Discounts { get; set; }
        #endregion
    }
}