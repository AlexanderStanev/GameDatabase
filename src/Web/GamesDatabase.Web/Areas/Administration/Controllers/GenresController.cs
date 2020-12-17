namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Web.Models.InputModels;
    using GamesDatabase.Web.Models.ViewModels.Genres;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class GenresController : AdministrationBaseController
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
            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Edit(int id)
        {
            var genre = this.genresService.GetGenreById<GenreInputModel>(id);
            return this.View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GenreInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.genresService.Update(input);
            return this.RedirectToAction(nameof(this.All));
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
