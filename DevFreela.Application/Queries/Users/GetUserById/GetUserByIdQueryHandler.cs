﻿using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserById(request.Id);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuário não existe");
            }

            var model = UserViewModel.FromEntity(user!);
            return ResultViewModel<UserViewModel>.Success(model);
        }
    }
}
