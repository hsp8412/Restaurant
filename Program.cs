using System;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            using RestaurantContext context = new RestaurantContext();

            var kungPaoChicken = context.Dishes.Where(d => d.Name == "Kung Pao Chicken").FirstOrDefault();
            if (kungPaoChicken is Dish)
            {
                kungPaoChicken.Price = 13.85M;
            }
            context.SaveChanges();


            var dishes = context.Dishes.Where(d => d.Price > 11m).OrderBy(d => d.Name);
            foreach (Dish d in dishes)
            {
                Console.WriteLine($"id: {d.Id}");
                Console.WriteLine($"Name: {d.Name}");
                Console.WriteLine($"Price: {d.Price}");
                Console.WriteLine(new String('-', 20));
            }
        }
    }


}

