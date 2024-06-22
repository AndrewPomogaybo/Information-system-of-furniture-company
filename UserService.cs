using ShopMetta.Models;
using System.Linq;


namespace ShopMetta
{
    public class UserService
    {
        private readonly DataBaseContext _context = new DataBaseContext();

        public UserService(DataBaseContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void RegisterUser(string name, string surname, string login, string password, int role)
        {
            var user = new User
            {
                User_name = name,
                User_surname = surname,
                User_login = Hasher.HashString(login),
                User_password = Hasher.HashString(password),
                User_role = role
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool LoginUser(string login, string password)
        {
            var users = _context.Users.ToList();

            var hashedLogin = Hasher.HashString(login);
            var user = users.SingleOrDefault(u => Hasher.VerifyHash(u.User_login, login));
            if (user == null)
            {
                return false;
            }

            return Hasher.VerifyHash(user.User_password, password);
        }
    }
}
