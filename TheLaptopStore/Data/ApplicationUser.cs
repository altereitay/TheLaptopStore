using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TheLaptopStore.Data
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "ID must be 9 numbers long")]
        public string PersonalID { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "First Name must start with uppercase latter and be at least 2 characters length")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "Last Name must start with uppercase latter and be at least 2 characters length")]
        public string LastName { get; set; }

        public CreditCard [] creditCards { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "City must start with uppercase latter and be at least 2 characters length")]
        public string City { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]+$", ErrorMessage = "Street name must start with uppercase latter and be at least 2 characters length")]
        public string StreetName { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,}$", ErrorMessage = "Building number are digits only")]
        public int BuildingNumber { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,}$", ErrorMessage = "Apartment number are digits only")]
        public int ApartmentNumber { get; set; }
    }
}
