using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
namespace WebApp.Controllers
{
   public class PeopleController : Controller
   {
      private readonly RepositoryPeopleImplemetation repositoryPeople;

      public PeopleController(RepositoryPeopleImplemetation repositoryPeople)
      {
         this.repositoryPeople = repositoryPeople;
      }

      public async Task<ActionResult> Index()
      {
         return View(await repositoryPeople.ToListAsync());
      }

      public async Task<ActionResult> Details(int id)
      {
         return await GetModelDefaultAsync(id);
      }

      public ActionResult Create()
      {
         return View("CreateOrUpdate");
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Create(People model)
      {
         try
         {
            if (ModelState.IsValid)
            {
               await repositoryPeople.AddAsync(model);
            }
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      public async Task<ActionResult> Edit(int id)
      {
         return await GetModelDefaultAsync(id, "CreateOrUpdate");
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Edit(int id, People model)
      {
         try
         {
            if (ModelState.IsValid)
            {
               await repositoryPeople.EditAsync(model);
            }
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      public async Task<ActionResult> Delete(int id)
      {
         return await GetModelDefaultAsync(id);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Delete(int id, People model)
      {
         try
         {
            var result = await repositoryPeople.FindAsync(id);
            if (result is not null)
            {
               await repositoryPeople.DeleteAsync(result);
            }
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      public async Task<ViewResult> GetModelDefaultAsync(int id, string? view = null)
      {
         var model = await repositoryPeople.FindAsync(id);
         return view is not null ? View(view, model) : View(model);
      }
   }
}
