using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

