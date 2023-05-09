using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestVK.Entities;

namespace TestVK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly DataContext _context;

        public MainController(DataContext context)
        {
            _context = context;
        }
        // Get all users
        // GET: api/<APIController>
        [HttpGet]
        public string GetUsers()
        {
            var users = _context.Users.ToList();
            return JsonConvert.SerializeObject(users);
        }

        
        // Get one user by id
        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public string GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return JsonConvert.SerializeObject(user);
        }

        // Create new user
        // POST api/<APIController>
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            var sameLogin = _context.Users.FirstOrDefault(u => u.Login == user.Login);
            if (sameLogin != null && sameLogin.CreatedDate.AddSeconds(5) < DateTime.Now)
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetUserById), new { id = user.Id });
            }
            return BadRequest();
        }

        // Delete user by id
        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserState = _context.UserStates.First(x => x.Code == UserState.Codes.Blocked).Id;
            
            _context.SaveChanges();

            return NoContent();
        }
    }
}
