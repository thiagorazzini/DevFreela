using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.CompleteProject
{
    public class CompleteProjectCommandHandler : IRequestHandler<CompleteProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;
        public CompleteProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.Id);

            if (project == null)
            {
                return ResultViewModel<ProjectItemViewModel>.Error("Projeto não existe");
            }

            project.Complete();

            await _repository.Update(project);

            return ResultViewModel.Success();
        }
    }
}
