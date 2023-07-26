using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel_Booking_Backend.Models;
using Hotel_Booking_Backend.Services;

namespace User_Booking_Backend.Controllers
{
    [ApiController]
    [Route("users/{userId}/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /users/{userId}/users
        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsersInOneUser(int userId)
        {
            return await _userService.GetUserById(userId);
        }

        // GET: /users/{userId}/users/{userId}
        [HttpGet("{userId}")]
        public async Task<User> GetUser(int userId, int userId)
        {
            return await _userService.GetUserByUserIdAndUserId(userId, userId);
        }

        // POST: /users/{userId}/users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            var createdUser = await _userService.AddUserToUser(user);
            return CreatedAtAction(nameof(GetUser), new { userId = createdUser.UserId, userId = createdUser.Id }, createdUser);
        }

        // PUT: /users/{userId}/users/{userId}
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, int userId, [FromBody] User user)
        {
            if (userId != user.Id)
            {
                return BadRequest("The provided userId does not match the user's Id.");
            }

            await _userService.UpdateUser(user);
            return NoContent();
        }

        // DELETE: /users/{userId}/users/{userId}
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId, int userId)
        {
            await _userService.DeleteUser(userId, userId);
            return NoContent();
        }
    }
}
