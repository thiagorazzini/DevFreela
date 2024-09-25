﻿using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectCommand : IRequest<ResultViewModel>
    {
        public int IdProject { get; set; }
        public string Title { get; set; } = string.Empty!;
        public string Description { get; set; } = string.Empty!;
        public decimal TotalCost { get; set; }
    }
}
