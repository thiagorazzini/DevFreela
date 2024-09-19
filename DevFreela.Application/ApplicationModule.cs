using DevFreela.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceProvider)
        {
            serviceProvider
                .AddServices();
            return serviceProvider;
        }

        private static IServiceCollection AddServices(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IProjectService, ProjectService>();
            return serviceProvider;
        }
    }
}
