using System.ComponentModel.DataAnnotations;

namespace Logistics.DAL.EntityModels.Transport
{
    public class TruckEntity : IIdentity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TruckPlateNumber { get; set; }
    }
}