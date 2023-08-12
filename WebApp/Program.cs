using Connections;
using Repositories;
namespace WebApp
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);

         builder.Services.AddControllersWithViews();
         builder.Services.AddFluentNibernateConnection(builder.Configuration.GetConnectionString("FluentNhibernateDatabaseDefault") ?? throw new Exception("Error Connection"));
         builder.Services.AddRepositories();

         var app = builder.Build();

         if (!app.Environment.IsDevelopment())
         {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
         }

         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseRouting();
         app.UseAuthorization();
         app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
         app.Run();
      }
   }
}