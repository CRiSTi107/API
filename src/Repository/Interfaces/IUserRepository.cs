using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        bool SaveChanges();

        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmailAndPassword(string Email, string Password);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }

}