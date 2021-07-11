using System.Collections.Generic;
using Api.Models;

namespace Api.Data
{
    public class UserRepository : IUserRepository
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
                new User{Id = 1, Email="Ioan@gmail.com", FirstName="Ioan", LastName="Voiculescu", Password="hellothere"},
                new User{Id = 1, Email="Razvan@yahoo.com", FirstName="Razvan", LastName="Pantilie", Password="hellothere"}

            };

            return users;
        }

        public User GetUserById(int id)
        {
            return new User { Id = 1, Email = "CRiSTi@protonmail.com", FirstName = "Cristian", LastName = "Voiculescu", Password = "hellothere" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}