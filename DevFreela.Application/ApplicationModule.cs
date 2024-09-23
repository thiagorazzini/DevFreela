using DevFreela.Application.Commands.InsertComment;
using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Models;
using DevFreela.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceProvider)
        {
            serviceProvider
                .AddServices()
                .AddHandler();

            return serviceProvider;
        }

        private static IServiceCollection AddServices(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IProjectService, ProjectService>();
            return serviceProvider;
        }

        private static IServiceCollection AddHandler(this IServiceCollection serviceProvider) 
        {
            serviceProvider.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());

            serviceProvider.AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, ValidateInsertProjectCommandBehavior>();
            return serviceProvider;
        }
    }
}
