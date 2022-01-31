using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticaBlog.Entities;
using PracticaBlog.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticaBlog.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly CommentService commentService;
        public CommentController(CommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> Get()
        {
            return await commentService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetById(int id)
        {
            var entity = await commentService.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Post(Comment comment)
        {
            await commentService.AddComment(comment);
            return comment;
        }

        [HttpPut]
        public async Task<ActionResult<Comment>> Put(Comment comment)
        {
            var entity = await commentService.GetById(comment.Id);
            if (entity == null)
            {
                return NotFound();
            }
            await commentService.PutComment(comment);
            return entity;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> Delete(int id)
        {
            var entity = await commentService.Delete(id);
            if (entity == null)
            {
                return BadRequest("User Not Found");
            }
            return entity;
        }
    }
}
