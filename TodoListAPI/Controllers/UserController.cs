using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using System.Net.WebSockets;
using TodoListAPI.Data;
using TodoListAPI.Model;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TodoDbContext dbContext;

        public UserController(TodoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await dbContext.Users.ToListAsync();
            if (users == null) return NotFound();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await dbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if(user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("{email}")]
        public async Task <IActionResult> GetUsersEmail(string email)
        {
            var users = await dbContext.Users.Where (u => u.Email == email).FirstOrDefaultAsync();
            if (users == null) return NotFound();
            return Ok(users);
        }
        [HttpGet ("{search}")]
        public async Task <IActionResult> GetBySearch (string search)
        {
            var users = await dbContext.Users.Where(u => u.Search == search).FirstOrDefaultAsync();
            if (users == null) return NotFound();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserModel addUser)
        {
            var user = new UserModel();
            user.Id = Guid.NewGuid();
            user.Name = addUser.Name;
            user.Email = addUser.Email;
            user.Password = addUser.Password;
            user.Created = DateTime.Now;
            await dbContext.Users.AddAsync(user);
            dbContext.SaveChanges();
            return Ok(user);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, AddUserModel addUser)
        {
            var user = await dbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user == null) return NotFound();
            user.Email = addUser.Email;
            user.Name = addUser.Name;
            user.Password = addUser.Password;
            dbContext.SaveChanges();
            return Ok(user);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task <IActionResult> DeleteUser (Guid id, AddUserModel deleteUser)
        {
            var user = await dbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
