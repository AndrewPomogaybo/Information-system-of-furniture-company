

using System.ComponentModel.DataAnnotations;

namespace ShopMetta.Models
{
    public class OverallStatistic
    {
        [Key]
        public int Id {  get; set; }
        public int TotalQuantitySold { get; set; }
        public int TotalRevenue { get; set;}
    }

}
