using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.Projects.InsertComment
{
    public class InsertCommentCommandHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly IProjectRepository _repository;

        public InsertCommentCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.Exists(request.IdProject);

            if (project is false)
            {
                return ResultViewModel<ProjectItemViewModel>.Error("Projeto não existe");
            }

            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _repository.AddComment(comment);

            return ResultViewModel.Success();
        }
    }
}
