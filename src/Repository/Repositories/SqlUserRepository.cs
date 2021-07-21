using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
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
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.User.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.User.ToList();
        }

        public User GetUserByEmailAndPassword(string Email, string Password)
        {
            return _context.User.FirstOrDefault(user => user.Email == Email && user.Password == Password);
        }

        public User GetUserById(int id)
        {
            return _context.User.FirstOrDefault(user => user.Id == id);
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateUser(User user)
        {
            //Nothing to do because EFCore does the job for us
        }

        Task<IEnumerable<User>> IUserRepository.GetAllUsers()
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetUserByEmailAndPassword(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}