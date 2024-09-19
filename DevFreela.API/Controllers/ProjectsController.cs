using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        public ProjectsController(DevFreelaDbContext context)
        {
            _context = context;
        }

        // GET api/projects?search=crm
        [HttpGet]
        public IActionResult Get(string search = "", int page = 0, int size = 3)
        {

            return Ok();
        }

        //GET api/projects/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           

            return Ok();
        }

        // POST api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {

            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        // PUT api/projects/1234
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            return NoContent();
        }

        // DELETE api/projects/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {


            return NoContent();
        }

        // PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {

            return NoContent();
        }

        // PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            return Ok();
        }

        // POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model)
        {


            return Ok();
        }

    }
}
