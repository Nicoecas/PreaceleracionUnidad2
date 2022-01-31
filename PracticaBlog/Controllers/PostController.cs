using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticaBlog.Entities;
using PracticaBlog.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticaBlog.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService postService;
        public PostController(PostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            return await postService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById(int id)
        {
            var entity = await postService.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> Post(Post post)
        {
            await postService.AddPost(post);
            return post;
        }

        [HttpPut]
        public async Task<ActionResult<Post>> Put(Post post)
        {
            var entity = await postService.GetById(post.Id);
            if (entity == null)
            {
                return NotFound();
            }
            await postService.PutPost(post);
            return entity;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> Delete(int id)
        {
            var entity = await postService.Delete(id);
            if (entity == null)
            {
                return BadRequest("User Not Found");
            }
            return entity;
        }
    }
}
