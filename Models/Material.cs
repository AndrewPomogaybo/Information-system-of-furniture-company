using System.ComponentModel.DataAnnotations;


namespace ShopMetta.Models
{
    public class Material
    {
        [Key]
        public int Material_id { get; set; }
        public string Material_name { get; set; }
    }
}
