using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthDate, List<string> skills)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skills = skills;
        }

        public string FullName { get; private set; } = string.Empty!;
        public string Email { get; private set; } = string.Empty!;
        public DateTime BirthDate { get; private set; }
        public List<string> Skills { get; private set; } = new List<string>();

        public static UserViewModel FromEntity(User user)
        {
            var skills = user.Skills.Select(u => u.Skill.Description).ToList();

            return new UserViewModel(user.FullName, user.Email, user.BirthDate, skills);
        }
    }
}
