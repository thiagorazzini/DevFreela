using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsCommandHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectItemViewModel>>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectsCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<ProjectItemViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAll();

            var model = projects.Select(p => ProjectItemViewModel.FromEntity(p)).ToList();

            return ResultViewModel<List<ProjectItemViewModel>>.Success(model);
        }
    }
}
