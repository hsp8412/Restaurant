using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Dtos;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishesController : ControllerBase
    {
        private readonly IRestaurantRepo _repository;
        private readonly IMapper _mapper;

        public DishesController(IRestaurantRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DishReadDto>> GetAllDishes()
        {
            var dishes = _repository.GetAllDishes();

            return Ok(_mapper.Map<IEnumerable<DishReadDto>>(dishes));
        }

        [HttpGet("{id}", Name = "GetDishById")]
        public ActionResult<DishReadDto> GetDishById(int id)
        {
            var dish = _repository.GetDishByID(id);
            if (dish != null)
            {
                return Ok(_mapper.Map<DishReadDto>(dish));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<DishReadDto> CreateDish(DishCreateDto dishCreateDto)
        {
            var dish = _mapper.Map<Dish>(dishCreateDto);
            _repository.CreateDish(dish);
            _repository.SaveChanges();

            var dishReadDto = _mapper.Map<DishReadDto>(dish);

            return CreatedAtRoute(nameof(GetDishById), new { Id = dishReadDto.Id }, dishReadDto);
        }
    }
}