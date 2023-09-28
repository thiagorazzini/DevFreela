using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu Projeto ASPNET Core 1", "Minha Descricao de Projeto 1", 1, 1, 10000),
                new Project("Meu Projeto ASPNET Core 2", "Minha Descricao de Projeto 2", 1, 1, 20000),
                new Project("Meu Projeto ASPNET Core 3", "Minha Descricao de Projeto 3", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User("Thiago Razzini", "thiagorazzini@devtv.com.br", new DateTime(1997, 04, 05)),
                new User("Thiago Araujo", "thiagoaraujo@devtv.com.br", new DateTime(1997, 08, 11)),
                new User("David Motta", "davidmotta@devtv.com.br", new DateTime(1980, 07, 05))
            };

            Skills = new List<Skill>
            {
                new Skill(".Net Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }

    }
}
