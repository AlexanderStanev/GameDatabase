namespace GamesDatabase.Web.Controllers
{
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Web.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class GenresController : BaseController
    {
        private readonly IGenresService genresService;

        public GenresController(IGenresService genresService)
        {
            this.genresService = genresService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Details(string id)
        {
            // TODO: Genre view model needed
            var genre = this.genresService.GetGenreById<DetailedGameViewModel>(id);
            return this.View(genre);
        }
    }
}
