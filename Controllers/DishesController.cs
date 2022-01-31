using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPut("{id}")]
        public ActionResult UpdateDish(int id, DishUpdateDto dishUpdateDto)
        {
            var dishFromRepo = _repository.GetDishByID(id);
            if (dishFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(dishUpdateDto, dishFromRepo);

            _repository.UpdateDish(dishFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        [HttpPatch("{id}")]
        public ActionResult PartialDishUpdate(int id, JsonPatchDocument<DishUpdateDto> patchDoc)
        {
            var dishFromRepo = _repository.GetDishByID(id);
            if (dishFromRepo == null)
            {
                return NotFound();
            }

            var dishToPatch = _mapper.Map<DishUpdateDto>(dishFromRepo);
            patchDoc.ApplyTo(dishToPatch, ModelState);
            if (!TryValidateModel(dishToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(dishToPatch, dishFromRepo);

            _repository.UpdateDish(dishFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteDish(int id)
        {
            var dishFromRepo = _repository.GetDishByID(id);
            if (dishFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteDish(dishFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}