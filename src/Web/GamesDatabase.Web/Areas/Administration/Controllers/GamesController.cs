using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    public class GamesController : AdministrationBaseController
    {
        private readonly IGamesService gamesService;
        private readonly IGenresService genresService;

        public GamesController(
            IGamesService gamesService,
            IGenresService genresService)
        {
            this.gamesService = gamesService;
            this.genresService = genresService;
        }

        public IActionResult Create()
        {
            ViewData["Genres"] = genresService.GetAllGenres()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            var id = await gamesService.Create(input);
            return RedirectToAction("Details", "Games", new { id });
        }

        public IActionResult Edit(int id)
        {
            return View($"Edit/{id}");
        }

        [HttpPost]
        public IActionResult Edit(GameInputModel game)
        {

            var id = 0;
            return RedirectToAction($"Details/{id}", "Games");
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return RedirectToAction("Index", "Games");
        }
    }
}
