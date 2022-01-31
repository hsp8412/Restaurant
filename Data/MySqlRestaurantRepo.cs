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

        public void CreateDish(Dish dish)
        {
            if (dish == null)
            {
                throw new ArgumentNullException(nameof(dish));
            }

            _context.Dishes.Add(dish);
        }

        public void DeleteDish(Dish dish)
        {
            if (dish == null)
            {
                throw new ArgumentNullException(nameof(dish));
            }

            _context.Dishes.Remove(dish);
        }

        public IEnumerable<Dish> GetAllDishes()
        {
            return _context.Dishes.ToList();
        }

        public Dish GetDishByID(int id)
        {
            return _context.Dishes.FirstOrDefault(d => d.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateDish(Dish dish)
        {
            //Nothing here
        }
    }
}