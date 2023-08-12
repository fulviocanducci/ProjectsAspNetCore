using Microsoft.Extensions.DependencyInjection;
namespace Repositories
{
   public static class Extensions
   {
      public static IServiceCollection AddRepositories(this IServiceCollection services)
      {
         services.AddScoped<RepositoryPeopleImplemetation, RepositoryPeople>();
         return services;
      }
   }
}
