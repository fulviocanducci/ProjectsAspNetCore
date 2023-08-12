using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
namespace Connections
{
   public static class Extensions
   {
      public static IServiceCollection AddFluentNibernateConnection(this IServiceCollection services, string connectionString)
      {
         ISessionFactory sessionFactory = Fluently.Configure()
            .Database(MySQLConfiguration.Standard.ConnectionString(connectionString).ShowSql())
            .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Mappings.PeopleMapping>())
            .BuildSessionFactory();
         services.AddSingleton(x => sessionFactory);
         services.AddScoped(x => sessionFactory.OpenSession());
         return services;
      }

      public static IServiceCollection AddFluentNibernateConnection(this IServiceCollection services, IConfiguration configuration)
      {
         return services.AddFluentNibernateConnection
            (
               configuration.GetConnectionString("FluentNhibernateDatabaseDefault")
               ?? throw new System.Exception("ConnectionString error value default: FluentNhibernateDatabaseDefault")
            );
      }
   }
}