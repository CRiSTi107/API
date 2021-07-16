using Api.Entities;

namespace Api.Models
{
    public class AuthenticateResponse
    {
        public User user;
        public string token;

        public AuthenticateResponse(User user, string token)
        {
            this.user = user;
            this.token = token;
        }

        // public int Id { get; set; }

    }
}