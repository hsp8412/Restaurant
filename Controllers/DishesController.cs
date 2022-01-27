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

        [HttpGet("{id}")]
        public ActionResult<DishReadDto> GetDishById(int id)
        {
            var dish = _repository.GetDishByID(id);
            if (dish != null)
            {
                return Ok(_mapper.Map<DishReadDto>(dish));
            }
            return NotFound();
        }
    }
}