using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.Skills.InsertSkill
{
    public class InsertSkillCommand : IRequest<ResultViewModel<int>>
    {
        public string Description { get; set; } = string.Empty;

        public Skill ToEntity()
            => new Skill(Description);
    }
}
