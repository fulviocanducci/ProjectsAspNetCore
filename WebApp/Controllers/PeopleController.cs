using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

      public ActionResult Details(int id)
      {
         return View();
      }

      public ActionResult Create()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create(IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      public ActionResult Edit(int id)
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit(int id, IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }

      public ActionResult Delete(int id)
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Delete(int id, IFormCollection collection)
      {
         try
         {
            return RedirectToAction(nameof(Index));
         }
         catch
         {
            return View();
         }
      }
   }
}
