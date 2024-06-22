using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMetta.Models
{
    public class CreateOrder
    {
        [Key]
        public int Creation_id { get; set; }
        public int Creation_client { get; set; }
        public string Creation_name { get; set; }
        public string Creation_description { get; set; }
        public int Creation_sum { get; set; }
        public int Creation_status { get; set; }
        public string Creation_master { get; set; }
        public DateTime? Creation_date { get; set; }


        [ForeignKey("Creation_status")]
        public Status Status { get; set; }

        [ForeignKey("Creation_client")]
        public Client Client { get; set; }
    }
}
