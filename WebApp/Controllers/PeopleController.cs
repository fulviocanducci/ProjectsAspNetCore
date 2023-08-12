using Canducci.Pagination;
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

      public async Task<ActionResult> Index(int? current, string filter)
      {
         ViewBag.Filter = filter;
         Paginated<People>? result = default;
         if (!string.IsNullOrEmpty(filter))
         {
            result = await repositoryPeople.PageAsync(current ?? 1, 4, w => w.Name.Contains(filter), c => c.OrderBy(x => x.Name));
         }
         else
         {
            result = await repositoryPeople.PageAsync(current ?? 1, 4, w => w.Id > 0, c => c.OrderBy(x => x.Name));
         }
         return View(result);
      }

      public async Task<ActionResult> Details(long id)
      {
         return await GetModelAndViewDefaultAsync(id);
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

      public async Task<ActionResult> Edit(long id)
      {
         return await GetModelAndViewDefaultAsync(id, "CreateOrUpdate");
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Edit(long id, People model)
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

      public async Task<ActionResult> Delete(long id)
      {
         return await GetModelAndViewDefaultAsync(id);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Delete(long id, People model)
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

      public async Task<ViewResult> GetModelAndViewDefaultAsync(long id, string? view = null)
      {
         var model = await repositoryPeople.FindAsync(id);
         return view is not null ? View(view, model) : View(model);
      }
   }
}
