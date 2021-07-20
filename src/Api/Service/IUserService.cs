using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models;

namespace Api.Service
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
    }
}