using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
    {
        public GetAllProjectsQuery(string search, int page, int size)
        {
            Search = search;
            this.page = page;
            this.size = size;
        }

        public string Search { get; set; }
        public int page { get; set; } = 1;
        public int size { get; set; } = 10;
    }
}
