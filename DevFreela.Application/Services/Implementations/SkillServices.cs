using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillServices : ISkillService
    {
        private readonly DevFreelaDbContext _dbcontext;
        public SkillServices(DevFreelaDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public List<SkillViewModel> GetAll()
        {
            var skills = _dbcontext.Skills;

            var skillsViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToList();

            return skillsViewModel;
        }
    }
}
