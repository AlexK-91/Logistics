using System.ComponentModel.DataAnnotations;

namespace Logistics.DAL.EntityModels.Customers
{
    public class CustomerEntity : IIdentity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
