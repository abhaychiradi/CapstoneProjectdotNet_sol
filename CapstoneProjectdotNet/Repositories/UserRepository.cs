using CapstoneProjectdotNet.Data;
using CapstoneProjectdotNet.Interfaces;
using CapstoneProjectdotNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace CapstoneProjectdotNet.Repositories
{
    public class UserRepository : IUser
    {
        public DataContext _context;
        public UserRepository(DataContext context) 
        {
            _context = context;
        }

        

        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool DeleteUser(int UserId)
        {
            var user = GetUser(UserId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return Save();

        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _context.Users.ToList();

            return users;
        }

        public User GetUser(int UserId)
        {
            var user = _context.Users.Where(x => x.UserId == UserId).FirstOrDefault();

            return user;
        }

        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
