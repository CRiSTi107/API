using System;
using System.Collections.Generic;
using Api.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using Dapper.FastCrud;
using System.Threading.Tasks;
using System.Linq;

namespace Api.Data
{
    public class NpgsqlUserRepository : BaseRepository, IUserRepository
    {
        public NpgsqlUserRepository(Lazy<NpgsqlConnection> conn)
            : base(conn)
        {
        }

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
            throw new System.NotImplementedException();
        }

        public async Task<User> GetUserByEmailAndPassword(string Email, string Password)
        {
            return (await DatabaseConnection.FindAsync<User>(statementOptions => statementOptions
                .Where($"{nameof(User.Email):C}=@Email and {nameof(User.Password):C}=@Password")
                .WithParameters(new { Email, Password }))).ToList().FirstOrDefault();
        }

        public async Task<User> GetUserById(int Id)
        {

            return (await DatabaseConnection.FindAsync<User>(statementOptions => statementOptions
                .Where($"{nameof(User.Id):C}=@Id")
                .WithParameters(new { Id }))).ToList().FirstOrDefault();



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