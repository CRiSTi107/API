using System;
using Api.Controllers;
using Api.Data;
using Api.Service;
using Api.Helpers;
using Microsoft.Extensions.Options;
using Moq;
using AutoMapper;
using Api.Entities;
using Api.DTOs;
using Api.Models;

namespace test
{
    public class UserControllerTest
    {
        UsersController usersController;

        public UserControllerTest()
        {
            AppSettings app = new AppSettings() { Secret = "The algorithm HS256 requires the SecurityKey.KeySize to be greater than 128 bits and your key has just 48." };
            var mock = new Mock<IOptions<AppSettings>>();
            mock.Setup(ap => ap.Value).Returns(app);

            var mappingService = new Mock<IMapper>();
            mappingService.Setup(m => m.Map<User, UserReadDTO>(It.IsAny<User>()));
            mappingService.Setup(m => m.Map<UserCreateDTO, User>(It.IsAny<UserCreateDTO>()));
            mappingService.Setup(m => m.Map<UserUpdateDTO, User>(It.IsAny<UserUpdateDTO>()));
            mappingService.Setup(m => m.Map<User, UserUpdateDTO>(It.IsAny<User>()));
            mappingService.Setup(m => m.Map<User, AuthenticateResponse>(It.IsAny<User>()));

            IUserRepository repository = new UserMockRepository();
            IUserService service = new UserService(repository, mock.Object);

            usersController = new UsersController(repository, service, mappingService.Object);

            AuthenticateResponse response = service.Authenticate(new AuthenticateRequest()
            {
                Email = "CRiSTi@protonmail.com",
                Password = "hellothere"
            }).Result;

            Console.WriteLine(response.Id);

            response = service.Authenticate(new AuthenticateRequest()
            {
                Email = "CRiSTi@protonmail.com",
                Password = "notMyPassword"
            }).Result;

            if (response == null)
                Console.WriteLine("Invalid password");
        }
    }
}