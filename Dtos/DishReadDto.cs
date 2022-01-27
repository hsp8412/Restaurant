using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Dtos
{
    public class DishReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

    }
}

