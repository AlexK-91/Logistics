using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Logistics.DAL.EntityModels.Customers;

namespace Logistics.DAL.EntityModels.Orders
{
    public class OrderEntity : IIdentity
    {
        [Key]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [ForeignKey("CustomerId")]
        public CustomerEntity Customer { get; set; }
    }
}
