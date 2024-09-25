﻿using DevFreela.Application.Commands.Skills.InsertSkill;
using DevFreela.Application.Queries.Skills.GetAllSkills;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly DevFreelaDbContext _context;
        public SkillsController(IMediator mediator, DevFreelaDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        // GET api/skills
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSkillsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // POST api/skills
        [HttpPost]
        public async Task<IActionResult> Post(InsertSkillCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
