using Microsoft.AspNetCore.Mvc;
using tg_server.models;
using tg_server.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tg_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        // GET: api/<CommentsController>
        [HttpGet]
        public ActionResult<List<comment>> Get()
        {
            return commentService.Get();
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public ActionResult<comment> Get(string id)
        {
            var comment = commentService.Get(id);

            if(comment == null)
            {
                return NotFound($"Not found");
            }

            return comment;

        }

        // POST api/<CommentsController>
        [HttpPost]
        public ActionResult<comment> Post([FromBody] comment comment)
        {
            commentService.Create(comment);

            return CreatedAtAction(nameof(Get), new { id = comment.Id }, comment);
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var comment = commentService.Get(id);

            if (comment == null)
            {
                return NotFound($"Not found");
            }

            commentService.Delete(comment.Id);

            return Ok($"Comment Deleted");
        }
    }
}
