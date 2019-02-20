using System.Threading.Tasks;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    public class GenresController : AdministrationBaseController
    {
        private readonly IGamesService gamesService;
        private readonly IGenresService genresService;

        public GenresController(IGamesService gamesService, IGenresService genresService)
        {
            this.gamesService = gamesService;
            this.genresService = genresService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            var id = await genresService.Create(input);
            return RedirectToAction("Details", "Genres", new { id });
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(GameInputModel game)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return RedirectToAction("Index", "Games");
        }
    }
}
