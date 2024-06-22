using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShopMetta.Models
{
    public class Client
    {
        [Key]
        public int Client_id { get;set; }
        public string Client_name { get; set; }
        public string Client_surname { get; set; }
        public string Client_patronymic { get; set; }
        public int Client_age { get; set; }
        public string Client_phone { get; set; }

        [NotMapped]
        public string FullName => $"{Client_id} {Client_surname} {Client_name} {Client_patronymic}";

        public string MaskedPhoneNumber
        {
            get
            {
                if (Client_phone.Length > 4)
                {
                    return new string('*', Client_phone.Length - 4) + Client_phone.Substring(Client_phone.Length - 4);
                }
                return Client_phone;
            }
        }

        public string MaskedName
        {
            get
            {
                if (Client_name.Length > 1)
                {
                    return Client_name[0] + new string('*', Client_name.Length - 1);
                }
                return Client_name;
            }
        }

        public string MaskedPatronymic
        {
            get
            {
                if (Client_patronymic.Length > 1)
                {
                    return Client_patronymic[0] + new string('*', Client_patronymic.Length - 1);
                }
                return Client_patronymic;
            }
        }
    }
}
