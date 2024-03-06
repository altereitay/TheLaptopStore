using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TheLaptopStore.Data {
    [Table("ShoppingCart")]
    [PrimaryKey("laptopModel", "userId")]
    public class ShoppingCart {
        public Laptop laptop { get; set; }

        [ForeignKey("laptopModel")]
        public string laptopModel {  get; set; }
        public int quantity { get; set; }
        public string userId {  get; set; }
        public int totalPrice {  get; set; }
    }
}
