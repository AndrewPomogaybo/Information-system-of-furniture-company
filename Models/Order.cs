using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMetta.Models
{
    public class Order
    {
        [Key]
        public int Order_id { get; set; }
        public string Order_basket { get; set; }
        
        public int Order_client {  get; set; }
        
        public int Order_status { get; set; }
        public DateTime Order_date { get; set; }

        public int Order_sum { get; set; }

        [ForeignKey("Order_client")]
        public Client Client { get; set; }
        [ForeignKey("Order_status")]
        public Status Status { get; set; }
    }
}
