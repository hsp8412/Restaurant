using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Services
{
    public class DishService
    {
        RestaurantContext context = new RestaurantContext();

        public List<Dish> getAll()
        {
            var _dishes = context.Dishes;
            List<Dish> dishes = new List<Dish>();
            foreach (Dish d in _dishes)
            {
                Dish dish = new Dish(d.Name, d.Price);
                dishes.Add(dish);
            }
            return dishes;
        }
    }
}