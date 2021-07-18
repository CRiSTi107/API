using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using System.Linq;

namespace Api.Data
{
    public class UserMockRepository : IUserRepository
    {
        private List<User> users;

        public UserMockRepository()
        {
            users = new List<User>
            {
                new User{Id = 1, Email="CRiSTi@protonmail.com", FirstName="Cristian", LastName="Voiculescu", Password="hellothere"},
                new User{Id = 2, Email="Ioan@gmail.com", FirstName="Ioan", LastName="Voiculescu", Password="hellothere"},
                new User{Id = 3, Email="Razvan@yahoo.com", FirstName="Razvan", LastName="Pantilie", Password="hellothere"}
            };
        }

        public void CreateUser(User user)
        {
            users.Add(user);
        }

        public void DeleteUser(User user)
        {
            users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserByEmailAndPassword(string Email, string Password)
        {
            return users.Where(user => user.Email == Email && user.Password == Password).FirstOrDefault();
        }

        public User GetUserById(int id)
        {
            return users.Where(user => user.Id == id).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return true;
        }

        public void UpdateUser(User user)
        {
            for (int index = 0; index < users.Count; index++)
                if (users[index].Id == user.Id)
                    users[index] = user;
        }

        Task<User> IUserRepository.GetUserByEmailAndPassword(string Email, string Password)
        {
            User user = users.Where(user => user.Email == Email && user.Password == Password).FirstOrDefault();
            return Task.FromResult(user);
        }

        Task<User> IUserRepository.GetUserById(int id)
        {
            User user = users.Where(user => user.Id == id).FirstOrDefault();
            return Task.FromResult(user);
        }
    }
}