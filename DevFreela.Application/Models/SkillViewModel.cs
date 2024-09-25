using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class SkillViewModel
    {
        public SkillViewModel(int id, string description, DateTime createdAt, bool isDeleted, List<UserSkill> userSkills)
        {
            Id = id;
            Description = description;
            CreatedAt = createdAt;
            IsDeleted = isDeleted;
            UserSkills = userSkills;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<UserSkill> UserSkills { get; private set; }

        public static SkillViewModel FromEntity(Skill skill)
            =>  new(skill.Id, skill.Description, skill.CreatedAt, skill.IsDeleted, skill.UserSkills);

    }
}
