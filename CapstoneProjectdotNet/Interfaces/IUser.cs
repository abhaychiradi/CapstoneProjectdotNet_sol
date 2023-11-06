using CapstoneProjectdotNet.Models;

namespace CapstoneProjectdotNet.Interfaces
{
    public interface IUser
    {
        public IEnumerable<User> GetAllUsers();

        public User GetUser(int UserId);

        public bool CreateUser(User user);

        public bool DeleteUser(int UserId);

        public bool UpdateUser(User user);

    }
}
