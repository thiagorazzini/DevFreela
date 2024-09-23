using DevFreela.Application.Commands.InsertComment;
using DevFreela.Application.Services;
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
            config.RegisterServicesFromAssemblyContaining<InsertCommentCommand>());

            return serviceProvider;
        }
    }
}
