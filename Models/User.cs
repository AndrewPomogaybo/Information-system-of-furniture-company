using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShopMetta.Models
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string User_name { get; set;}
        public string User_surname { get; set;}
        public string User_login { get; set;}//Сущность пользователя
        public string User_password { get; set;}
        public int User_role { get; set;}

        [ForeignKey("User_role")]
        public Role Role { get; set;}

        public string MaskedPassword
        {
            
            get//Скрытие пароля
            {
                try
                {
                    return new string('*', User_password.Length - 2) + User_password.Substring(User_password.Length - 2);
                }
                catch
                {
                    return "Пароль слишком короткий!";
                }
            }
        }

        public string MaskedLogin
        {
            get//Крытие логина
            {
                try
                {
                    return new string('*', User_login.Length - 2) + User_login.Substring(User_login.Length - 2);
                }
                catch
                {
                    return "Логин слишком короткий!";
                }
            }
        }
    }
}
