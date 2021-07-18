using Api.Controllers;
using Api.Data;
using Api.Service;
using Api.Helpers;
using Microsoft.Extensions.Options;
using AutoMapper;

namespace test
{
    public class UserControllerTest
    {
        UsersController usersController;

        public UserControllerTest()
        {
            IUserRepository repository = new UserMockRepository();
            IUserService service = new UserService(repository, );

            usersController = new UsersController(repository, service, Mock<IMapper>);


        }
    }
}