using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheLaptopStore.Models
{
    public class CreditCard
    {
        [Required]
        [RegularExpression("^d{16}$", ErrorMessage = "Credit card number must be 16 digits only")]
        public int Number { get; set; }

        [Required]
        public string ExpDate { get; set; }

        [Required]
        [RegularExpression("^d{3}$", ErrorMessage = "CVV must be 3 digits only")]
        public int CVV{ get; set; }

        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "ID must be 9 numbers long")]
        public string ID { get; set; }
    }
}