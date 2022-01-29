using AutoMapper;
using Restaurant.Dtos;
using Restaurant.Models;

namespace Restaurant.Profiles
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            CreateMap<Dish, DishReadDto>();
            CreateMap<DishCreateDto, Dish>();
        }
    }
}