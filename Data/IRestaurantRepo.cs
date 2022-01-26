using Restaurant.Models;

namespace Restaurant.Data
{
    public interface IRestaurantRepo
    {
        IEnumerable<Dish> GetAllDishes();
        Dish GetDishByID(int id);

    }
}