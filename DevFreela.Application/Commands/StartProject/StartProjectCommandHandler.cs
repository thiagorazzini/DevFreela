using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;

        public StartProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetById(request.Id);

            if (project is null)
            {
                return ResultViewModel<ProjectItemViewModel>.Error("Projeto não existe");
            }

            project.Start();

            await _repository.Update(project);

            return ResultViewModel.Success();
        }
    }
}
