using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesDatabase.Web.Controllers
{
    public class GenresController : BaseController
    {
        private readonly IGenresService genresService;

        public GenresController(IGenresService genresService)
        {
            this.genresService = genresService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var genre = genresService.GetGenreById<DetailedGameViewModel>(id);
            return View(genre);
        }
    }
}
