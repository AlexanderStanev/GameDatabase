namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Web.Models.InputModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

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
            this.ViewData["Genres"] = this.genresService.GetAllGenres()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                });

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.gamesService.Create(input);
            return this.RedirectToAction("Details", "Games", new { id });
        }

        public IActionResult Edit(int id)
        {
            return this.View($"Edit/{id}");
        }

        [HttpPost]
        public IActionResult Edit(GameInputModel game)
        {
            var id = 0;
            return this.RedirectToAction($"Details/{id}", "Games");
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return this.RedirectToAction("Index", "Games");
        }
    }
}
