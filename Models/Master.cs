
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShopMetta.Models
{
    public class Master
    {
        [Key]
        public int Master_id { get; set; }
        public string Master_name { get; set; }
        public string Master_surname { get; set;}
        public int Master_qualification { get; set; }

        [ForeignKey("Master_qualification")]
        public Qualification Qualification { get; set; }

        [NotMapped]
        public string FullName => $"{Master_surname} {Master_name}";
    }
}
