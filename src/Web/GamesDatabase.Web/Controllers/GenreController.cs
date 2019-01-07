using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Models.ViewModels.Game;
using Microsoft.AspNetCore.Mvc;

namespace GamesDatabase.Web.Controllers
{
    public class GenreController : BaseController
    {
        private readonly IGenresService genresService;

        public GenreController(IGenresService genresService)
        {
            this.genresService = genresService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var genre = this.genresService.GetGenreById<GameDetailsViewModel>(id);
            return this.View(genre);
        }
    }
}
