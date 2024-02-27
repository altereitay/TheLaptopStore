using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLaptopStore.Data
{
    [Table("CreditCard")]
    public class CreditCard
    {
        [Key]
        [Required]
        [RegularExpression("^d{16}$", ErrorMessage = "Credit card number must be 16 digits only")]
        public int Number { get; set; }

        [Required]
        public string ExpDate { get; set; }

        [Required]
        [RegularExpression("^d{3}$", ErrorMessage = "CVV must be 3 digits only")]
        public int CVV { get; set; }

        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "ID must be 9 numbers long")]
        public string PersonalID { get; set; }
    }
}
