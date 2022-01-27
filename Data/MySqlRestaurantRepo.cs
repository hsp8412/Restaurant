using Restaurant.Models;

namespace Restaurant.Data
{
    public class MySqlRestaurantRepo : IRestaurantRepo
    {
        private readonly RestaurantContext _context;

        public MySqlRestaurantRepo(RestaurantContext context)
        {
            _context = context;
        }
        public IEnumerable<Dish> GetAllDishes()
        {
            return _context.Dishes.ToList();
        }

        public Dish GetDishByID(int id)
        {
            return _context.Dishes.FirstOrDefault(d => d.Id == id);
        }
    }
}