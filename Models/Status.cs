using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMetta.Models
{
    public class Status
    {
        [Key]
        public int Status_id { get; set; }
        public string Status_name { get; set; }
    }
}
