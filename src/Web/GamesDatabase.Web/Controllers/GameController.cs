using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GamesDatabase.Services.DataServices;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Models.ViewModels.Game;

namespace GamesDatabase.Web.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGamesService gamesService;

        public GameController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var game = this.gamesService.GetGameById<GameDetailsViewModel>(id);
            return this.View(game);
        }

        public IActionResult List()
        {
            return View();
        }
    }
}