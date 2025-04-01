using lending_skills_backend.Models;
using lending_skills_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace YourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UsersRepository _userRepository;

        public UserController(UsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbUser>>> GetUsers()
        {
            return Ok(await _userRepository.GetUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DbUser>> GetUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        //[HttpPost]
        //public async Task<ActionResult> CreateUser(DbUser user)
        //{
        //    await _userRepository.AddUserAsync(user);
        //    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        //}
    }
}