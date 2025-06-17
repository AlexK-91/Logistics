using Logistics.DAL.EntityModels.Cargos;
using System.ComponentModel.DataAnnotations;

namespace Logistics.DAL.EntityModels.Transport
{
    public class TrailerEntity : IIdentity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TrailerPlateNumber { get; set; }

        public List<PalletEntity>? Pallets { get; set; }
    }
}
