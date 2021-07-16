using System.Collections.Generic;
using Api.Data;
using Api.DTOs;
using Api.Entities;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Api.Attributes;
using Api.Service;

namespace Api.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repository, IUserService userService, IMapper mapper)
        {
            _repository = repository;
            _userService = userService;
            _mapper = mapper;
        }

        // GET api/users
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetAllUsers()
        {
            IEnumerable<User> allUsers = _repository.GetAllUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDTO>>(allUsers));
        }

        // GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDTO> GetUserById(int id)
        {
            User user = _repository.GetUserById(id);
            if (user != null)
                return Ok(_mapper.Map<UserReadDTO>(user));
            else
                return NotFound();
        }

        // POST api/users
        [HttpPost]
        public ActionResult<UserReadDTO> CreateUser(UserCreateDTO userCreateDTO)
        {
            // Validate data

            var userModel = _mapper.Map<User>(userCreateDTO);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDTO>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.Id }, userReadDto);

            //return Ok(userReadDto);
        }

        // PUT api/users/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDTO userUpdateDTO)
        {
            var userModelFromRepository = _repository.GetUserById(id);

            if (userModelFromRepository == null)
                return NotFound();

            _mapper.Map(userUpdateDTO, userModelFromRepository);

            _repository.UpdateUser(userModelFromRepository);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/users/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDTO> patchDocument)
        {
            var userModelFromRepository = _repository.GetUserById(id);

            if (userModelFromRepository == null)
                return NotFound();

            var userToPatch = _mapper.Map<UserUpdateDTO>(userModelFromRepository);
            patchDocument.ApplyTo(userToPatch, ModelState);

            if (!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userToPatch, userModelFromRepository);

            _repository.UpdateUser(userModelFromRepository);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/users
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userModelFromRepository = _repository.GetUserById(id);

            if (userModelFromRepository == null)
                return NotFound();

            _repository.DeleteUser(userModelFromRepository);
            _repository.SaveChanges();

            return NoContent();
        }

        // POST api/users/authenticate
        [HttpPost("authenticate")]
        public ActionResult Authenticate(AuthenticateRequest authenticateRequest)
        {
            System.Console.WriteLine(authenticateRequest);

            var response = _userService.Authenticate(authenticateRequest);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}