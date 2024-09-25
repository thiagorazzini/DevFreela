using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceProvider)
        {
            serviceProvider
                .AddHandler()
                .AddValidation();

            return serviceProvider;
        }


        private static IServiceCollection AddHandler(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());

            serviceProvider.AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, ValidateInsertProjectCommandBehavior>();
            return serviceProvider;
        }

        private static IServiceCollection AddValidation(this IServiceCollection serviceProvider)
        {
            serviceProvider
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<InsertProjectCommand>();

            return serviceProvider;
        }
    }
}
