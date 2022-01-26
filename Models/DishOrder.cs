using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class DishOrder
    {
        public int Id { get; set; }

        [Required]
        public int DishId { get; set; }


        [Required]
        public Dish Dish { get; set; }

        [Required]
        public int Quantitiy { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public Order Order { get; set; }

    }
}