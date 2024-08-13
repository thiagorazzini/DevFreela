﻿using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class CreateProjectInputModel
    {
        public string Title { get; set; } = string.Empty!;
        public string Description { get; set; } = string.Empty!;
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public decimal TotalCost { get; set; }

        public Project ToEntity()
            => new Project(Title, Description, IdClient, IdFreelancer, TotalCost);
    }
}
