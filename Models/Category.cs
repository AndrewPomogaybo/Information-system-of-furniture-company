using System.ComponentModel.DataAnnotations;

namespace ShopMetta.Models
{
    public class Category
    {
        [Key]
        public int Category_id { get; set; }
        public string Category_name { get; set; }
    }
}
