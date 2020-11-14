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

        public async Task<IActionResult> All()
        {
            var genres = genresService.GetAllGenres();
            return this.View(genres);
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
            return this.RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit()
        {
            return this.View();
        }

        //[HttpPost]
        //  {  
        // TODO: Genre view model needed
        //public async Task<IActionResult> Edit( )
        //{
        //    return this.View();
        //}

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            return this.RedirectToAction("Index", "Games");
        }
    }
}
