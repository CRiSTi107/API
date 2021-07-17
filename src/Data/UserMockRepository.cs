using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Data
{
    public class UserMockRepository : IUserRepository
    {
        public void CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>
            {
                new User{Id = 1, Email="CRiSTi@protonmail.com", FirstName="Cristian", LastName="Voiculescu", Password="hellothere"},
                new User{Id = 2, Email="Ioan@gmail.com", FirstName="Ioan", LastName="Voiculescu", Password="hellothere"},
                new User{Id = 3, Email="Razvan@yahoo.com", FirstName="Razvan", LastName="Pantilie", Password="hellothere"}

            };

            return users;
        }

        public User GetUserByEmailAndPassword(string Email, string Password)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return new User { Id = 1, Email = "CRiSTi@protonmail.com", FirstName = "Cristian", LastName = "Voiculescu", Password = "hellothere" };
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        Task<User> IUserRepository.GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}