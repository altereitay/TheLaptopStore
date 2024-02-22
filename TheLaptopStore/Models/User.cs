using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheLaptopStore.Models
{
    public class User
    {
        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "ID must be 9 numbers long")]
        public string ID { get; set; }
        
        [Required]
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "First Name must start with uppercase latter and be at least 2 characters length")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "Last Name must start with uppercase latter and be at least 2 characters length")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^05[0-9]{8}$", ErrorMessage = "Phone number must start with 05 and by 10 digits long")]
        public string Phone { get; set; }

        public CreditCard[] creditCards { get; set; }

        [Required]
        [RegularExpression("^.{8,}$", ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "City must start with uppercase latter and be at least 2 characters length")]
        public string City { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,}$", ErrorMessage = "Building number are digits only")]
        public int BuildingNumber{ get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,}$", ErrorMessage = "Apartment number are digits only")]
        public int ApartmentNumber { get; set; }
    }
}