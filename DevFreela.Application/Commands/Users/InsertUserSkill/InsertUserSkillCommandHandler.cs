using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Users.InsertUserSkill
{
    public class InsertUserSkillCommandHandler : IRequestHandler<InsertUserSkillCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;

        public InsertUserSkillCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(InsertUserSkillCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Exists(request.UserId);

            if (user is false)
            {
                return ResultViewModel<ProjectItemViewModel>.Error("User não existe");
            }

            var userSkills = request.SkillsIds.Select(s => new UserSkill(request.UserId, s)).ToList();

            await _repository.AddUserSkill(userSkills);

            return ResultViewModel.Success();

        }
    }
}
