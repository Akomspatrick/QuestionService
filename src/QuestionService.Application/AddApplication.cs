using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace QuestionService.Application
{
    public static class AddApplicationClass
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return services.AddMediatR(assembly);
        }
    }

}
