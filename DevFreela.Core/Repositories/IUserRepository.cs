using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(int id);
        Task Add(User user);
        Task AddUserSkill(List<UserSkill> skill);
        Task<bool> Exists(int id);
    }
}
