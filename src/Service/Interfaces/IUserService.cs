using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
    }
}