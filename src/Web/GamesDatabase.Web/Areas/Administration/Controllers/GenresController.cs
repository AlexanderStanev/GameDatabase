namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Web.Models.InputModels;
    using Microsoft.AspNetCore.Mvc;

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
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.genresService.Create(input);
            return this.RedirectToAction("Details", "Genres", new { id });
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(GameInputModel game)
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return this.RedirectToAction("Index", "Games");
        }
    }
}
