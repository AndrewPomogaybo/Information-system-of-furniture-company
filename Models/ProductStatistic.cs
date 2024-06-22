using System.ComponentModel.DataAnnotations;

namespace ShopMetta.Models
{
    public class ProductStatistic
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int QuantitySold { get; set; }
        public int TotalRevenue { get; set; }
    }
}
