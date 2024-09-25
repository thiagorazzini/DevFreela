using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;

        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Users.AnyAsync(p => p.Id == id);
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddUserSkill(List<UserSkill> skill)
        {
            await _context.UserSkills.AddRangeAsync(skill);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _context.Users
                 .Include(u => u.Skills)
                     .ThenInclude(u => u.Skill)
                 .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }
    }
}
