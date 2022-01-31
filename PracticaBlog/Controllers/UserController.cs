using Microsoft.AspNetCore.Mvc;
using PracticaBlog.Services;
using PracticaBlog.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using PracticaBlog.Data;
using Microsoft.AspNetCore.Authorization;

namespace PracticaBlog.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await userService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var entity = await userService.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            await userService.AddUser(user);
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            var entity = await userService.GetById(user.Id);
            if (entity == null)
            {
                return NotFound();
            }
            await userService.PostUser(user);
            return entity;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var entity = await userService.Delete(id);
            if (entity == null)
            {
                return BadRequest("User Not Found");
            }
            return entity;
        }
    }
}
