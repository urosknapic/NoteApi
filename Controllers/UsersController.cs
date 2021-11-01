using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteApi.Data;
using NoteApi.Data.Tables;
using NoteApi.Dtos;

namespace NoteApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _noteMapper;

        public UsersController(IUserRepository repository, IMapper noteMapper)
        {
            _repository = repository;
            _noteMapper = noteMapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UserAuthenticateDto model)
        {
            User userItem = await _repository.Authenticate(model.Username, model.Password);

            if (userItem == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            var userModel = _noteMapper.Map<UserAuthenticateReadDto>(userItem);

            return Ok(userModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repository.GetAllUsers();
            return Ok(users);
        }
    }
}