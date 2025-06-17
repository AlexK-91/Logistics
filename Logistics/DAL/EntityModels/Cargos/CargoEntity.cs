using System.ComponentModel.DataAnnotations;

namespace Logistics.DAL.EntityModels.Cargos
{
    public class CargoEntity : IIdentity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<PalletEntity> Pallets { get; set; }
    }
}