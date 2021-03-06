using Restaurant.Models;

namespace Restaurant.Data
{
    public interface IRestaurantRepo
    {

        bool SaveChanges();
        IEnumerable<Dish> GetAllDishes();
        Dish GetDishByID(int id);

        void CreateDish(Dish dish);

        void UpdateDish(Dish dish);

        void DeleteDish(Dish dish);



    }
}