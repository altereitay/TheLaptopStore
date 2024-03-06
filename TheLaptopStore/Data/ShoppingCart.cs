using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLaptopStore.Data {
    [Table("ShoppingCart")]
    public class ShoppingCart {
        [Key]
        public Laptop laptop { get; set; }       
        public int quantity { get; set; }
        [Key]
        public string userId {  get; set; }
        public int totalPrice {  get; set; }
    }
}
