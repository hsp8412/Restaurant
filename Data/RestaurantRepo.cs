using Restaurant.Models;

namespace Restaurant.Data
{
    public class RestaurantRepo : IRestaurantRepo
    {
        public void CreateDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dish> GetAllDishes()
        {
            var dishes = new List<Dish>
            {
                new Dish{Id =1, Name = "Tofu", Price = 12M},
                new Dish{Id =2, Name = "Cake", Price = 13M}
            };
            return dishes;
        }

        public Dish GetDishByID(int id)
        {
            return new Dish { Id = 2, Name = "Cake", Price = 13M };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}