using System.Collections.Generic;
using Api.Entities;
using Api.Models;

namespace Api.Service
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}