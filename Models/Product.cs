using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.Imaging;


namespace ShopMetta.Models
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public int Product_category { get; set; }
        public string Product_description { get; set; }//Модель товара
        public string Product_colour { get; set; }
        public int Product_price { get; set; }
        public int Product_material { get; set; }
        public int Product_amount { get; set; }
        public string Product_image { get; set; }


        [ForeignKey("Product_category")]
        public Category Category { get; set; }
        [ForeignKey("Product_material")]       //Внешние ключи
        public Material Material { get; set; }
        [NotMapped]
        public BitmapImage Image { get; set; }
    }
}
