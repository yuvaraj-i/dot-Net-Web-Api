using Microsoft.AspNetCore.Mvc;
using UserDataProject.Models;

namespace UserDataProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private UserDataDbContext _dbContext;

        public UserController(UserDataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public User GetUser()
        {
            var user = new User()
            {
                Email = "yuvaraj@gmail.com",
                Name = "Yuvaraj",
                DateOfBirth = DateTime.Parse("31-03-2022")
            };

            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return user;
        }

        [HttpPost("save")]
        public ActionResult SaveUserData(User user)
        {
            if (IsUserExistByEmail(user.Email))
            {
                return BadRequest($"User with email id: {user.Email} is already present");
            }

            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return Ok(user.Id);
        }

        [HttpGet("all")]
        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
        {
            var user = _dbContext.Users.Find(id);

            if (user == null)
            {
                return NotFound($"User with id: {id} not found");
            }

            return Ok(user);
        }

        [HttpPut("update")]
        public void UpdateUserById(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser()
        {

        }

        private bool IsUserExistByEmail(string email)
        {
            var user = _dbContext.Users.Where(user => user.Email == email).ToList();

            if (user.Count == 0)
            {
                return false;
            }

            return true;
        }

    }
}
