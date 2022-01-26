using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishesController : ControllerBase
    {
        private readonly IRestaurantRepo _repository;

        public DishesController(IRestaurantRepo repository)
        {
            _repository = repository;
        }
        //private readonly RestaurantRepo _repository = new RestaurantRepo();
        [HttpGet]
        public ActionResult<IEnumerable<Dish>> GetAllDishes()
        {
            var dishes = _repository.GetAllDishes();

            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public ActionResult<Dish> GetDishById(int id)
        {
            var dish = _repository.GetDishByID(id);
            return Ok(dish);
        }
    }
}