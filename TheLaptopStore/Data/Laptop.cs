using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLaptopStore.Data
{
    [Table("Laptop")]
    public class Laptop
    {
        [Required]
        public int Ram { get; set; }

        [Required]
        public int SSD { get; set; }

        [Required]
        public string CPU { get; set; }

        [Required]
        public double ScreenSize { get; set; }

        [Required]
        public string GPU { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Maker { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Picture { get; set; }

        public bool IsOnSale { get; set; }

        public int SalePrecentage { get; set; }

        [Required]
        public int PopularityIndex { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Key]
        [Required]
        public string Model { get; set; }
    }
}
