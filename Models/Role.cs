using System.ComponentModel.DataAnnotations;


namespace ShopMetta.Models
{
    public class Role
    {
        [Key]
        public int Role_id { get; set; } //Модель роли пользователя
        public string Role_name { get; set; }
    }
}
