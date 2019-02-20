using System.ComponentModel.DataAnnotations;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesDatabase.Web.Controllers
{
    public class GamesController : BaseController
    {
        private readonly IGamesService gamesService;

        public GamesController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ByCategory(int id)
        {
            var games = this.gamesService.GetAllGamesByGenreId(id);
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = this.gamesService.GetGameById<DetailedGameViewModel>(id);
            return View(game);
        }

        public IActionResult Explore()
        {
            return View();
        }
    }
}