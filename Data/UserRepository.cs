using CyberWalletWeb.Models;

namespace CyberWalletWeb.Data
{
    public static class UserRepository
    {
        public static List<User> Users { get; set; } = new List<User>();

        private static int _nextId = 1;

        public static void Add(User user)
        {
            user.Id = _nextId++;
            Users.Add(user);
        }

        public static User? GetByEmail(string email)
        {
            return Users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public static User? ValidateUser(string email, string password)
        {
            return Users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && u.Password == password);
        }
    }
}