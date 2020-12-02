namespace GamesDatabase.Web.Controllers
{
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Web.Models.InputModels;
    using GamesDatabase.Web.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class GenresController : BaseController
    {
        private readonly IGamesService gamesService;
        private readonly IGenresService genresService;

        public GenresController(IGamesService gamesService, IGenresService genresService)
        {
            this.gamesService = gamesService;
            this.genresService = genresService;
        }

        public IActionResult All()
        {
            var genres = genresService.GetAllGenres<GenreViewModel>();
            return this.View(genres);
        }

        public async Task<IActionResult> Details(string id)
        {
            return this.View(id);
        }

        public async Task<IActionResult> Create()
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
            return this.RedirectToAction(nameof(this.All));
        }

        public async Task<IActionResult> Edit(string id)
        {
            return this.View(id);
        }

        [HttpPost]
        public async Task<IActionResult> Edit()
        {

            var id = "";
            // TODO: Genre view model needed
            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
