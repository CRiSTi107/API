using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Data
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public SqlUserRepository(UserContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.User.Add(user);
        }

        public void DeleteUser(User user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));
            
            _context.User.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.User.ToList();
        }
        public User GetUserById(int id)
        {
            return _context.User.FirstOrDefault(user => user.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateUser(User user)
        {
            //Nothing to do because EFCore does the job for us
        }
    }
}