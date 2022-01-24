using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime orderPlaced { get; set; }

        [Required]
        public DateTime orderFullfilled { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public ICollection<DishOrder> DishOrders { get; set; }
    }
}