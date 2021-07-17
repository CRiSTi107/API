using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Entities;
using Api.Models;

namespace Api.Service
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        Task<User> GetById(int id);
    }
}