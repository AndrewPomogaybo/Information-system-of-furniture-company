using System.ComponentModel.DataAnnotations;

namespace ShopMetta.Models
{
    public class Qualification
    {
        [Key]
        public int Qualification_id { get; set; }
        public string Qualification_name { get; set;}
    }
}
