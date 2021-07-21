using System.Collections.Generic;
using Domain.DTOs;
using Domain.Entities;
using Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Api.Attributes;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Repository.Interfaces;
using Service.Interfaces;
using Service.Services;

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
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetAllUsers()
        {
            IEnumerable<User> allUsers = await _userService.GetAll();
            return Ok(_mapper.Map<IEnumerable<UserReadDTO>>(allUsers));
        }

        // GET api/users/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserReadDTO>> GetUserById(int id)
        {
            User user = await _repository.GetUserById(id);
            if (user != null)
            {
                IEmailService emailService = new EmailService();
                var jsonObject = JsonConvert.SerializeObject(_mapper.Map<UserReadDTO>(user));
                emailService.SendEmail(jsonObject);
                return Ok(_mapper.Map<UserReadDTO>(user));
            }
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
        public async Task<ActionResult> UpdateUser(int id, UserUpdateDTO userUpdateDTO)
        {
            var userModelFromRepository = await _repository.GetUserById(id);

            if (userModelFromRepository == null)
                return NotFound();

            _mapper.Map(userUpdateDTO, userModelFromRepository);

            _repository.UpdateUser(userModelFromRepository);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/users/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDTO> patchDocument)
        {
            var userModelFromRepository = await _repository.GetUserById(id);

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
        public async Task<ActionResult> DeleteUser(int id)
        {
            var userModelFromRepository = await _repository.GetUserById(id);

            if (userModelFromRepository == null)
                return NotFound();

            _repository.DeleteUser(userModelFromRepository);
            _repository.SaveChanges();

            return NoContent();
        }

        // POST api/users/authenticate
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate(AuthenticateRequest authenticateRequest)
        {
            var response = await _userService.Authenticate(authenticateRequest);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpGet("password-reset/{token}")]
        public ActionResult PasswordReset(string token)
        {
            return Ok(token);
        }
    }
}