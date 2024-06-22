using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.Imaging;


namespace ShopMetta.Models
{
    public class Basket
    {
        [Key]
        public int Basket_id {  get; set; } 
        public int Basket_product {  get; set; } 
        public int Basket_amount {  get; set; }
        public int Basket_totalPrice {  get; set; }
        public string Basket_image { get; set; }



        [ForeignKey("Basket_product")]
        public Product Product { get; set; }

        [NotMapped]
        public BitmapImage Image { get; set; }

    }
}
