using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUserSkill
{
    public class InsertUserSkillCommand : IRequest<ResultViewModel>
    {
        public int[] SkillsIds { get; set; } = Array.Empty<int>();
        public int UserId { get; set; }
    }
}
