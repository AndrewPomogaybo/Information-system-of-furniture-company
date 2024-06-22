using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace ShopMetta
{
    public class MigrationService
    {
        private readonly DataBaseContext _context = new DataBaseContext();

        public MigrationService(DataBaseContext context)
        {
            _context = context;
        }

        public void MigrateUsers()
        {
            var users = _context.Users.ToList();
            foreach (var user in users)
            {
                if (!IsHashValid(user.User_login) || !IsHashValid(user.User_password))
                {
                    user.User_login = Hasher.HashString(user.User_login);
                    user.User_password = Hasher.HashString(user.User_password);
                    _context.Entry(user).State = EntityState.Modified;
                }
            }
            _context.SaveChanges();
        }

        private bool IsHashValid(string hash)
        {
            return hash.Contains(".");
        }
    }
}
