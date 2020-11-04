namespace GamesDatabase.Web.Controllers
{
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Web.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class GamesController : BaseController
    {
        private readonly IGamesService gamesService;

        public GamesController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult ByCategory(string id)
        {
            var games = this.gamesService.GetAllGamesByGenreId(id);
            return this.View(games);
        }

        public IActionResult Details(string id)
        {
            var game = this.gamesService.GetGameById<DetailedGameViewModel>(id);
            return this.View(game);
        }

        public IActionResult Explore()
        {
            return this.View();
        }
    }
}