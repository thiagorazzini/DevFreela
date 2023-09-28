using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectservice;
        public ProjectsController(IProjectService projectService)
        {

             _projectservice = projectService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectservice.GetAll(query);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var projects = _projectservice.GetById(id);
            return Ok(projects);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputProjectModel)
        {
            if (inputProjectModel.Title.Length > 50)
                return BadRequest();

            var projects = _projectservice.Create(inputProjectModel);
            return CreatedAtAction(nameof(GetById), new { id = projects}, inputProjectModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel updateProject)
        {
            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }

            _projectservice.Update(updateProject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectservice.Delete(id);
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment([FromBody] CreateCommentInputModel createComment)
        {
            _projectservice.CreateComment(createComment);
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectservice.Start(id);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectservice.Finish(id);
            return NoContent();
        }



    }
}
