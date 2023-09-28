using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    internal class UsersService : IUsersService
    {
        private readonly DevFreelaDbContext _dbcontext;
        public UsersService(DevFreelaDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public UsersViewModel GetById(int id)
        {
            var user = _dbcontext.Users.SingleOrDefault(u => u.Id == id);

            var usersViewModel = new UsersViewModel(
                user.FullName,
                user.Email,
                user.BirthDate
                );

            return usersViewModel;
        }

        public int Create(NewUserInputModel inputModel)
        {
            var user = new User(
                inputModel.FullName,
                inputModel.Email,
                inputModel.BirthDate
                );
            _dbcontext.Users.Add(user);

            return user.Id;
        }
    }
}
