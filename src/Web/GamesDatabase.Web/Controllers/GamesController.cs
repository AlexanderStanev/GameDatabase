using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GamesDatabase.Services.DataServices;
using GamesDatabase.Services.ViewModels;

namespace GamesDatabase.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly GamesService gamesService;

        public GamesController(GamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult View(int id)
        {
            
            var game = this.gamesService.GetGameById<GameViewModel>(id);
            return this.View(game);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(GameInputModel game)
        {
            return View();
        }

        [Authorize]
        public IActionResult Edit()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(GameInputModel game)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete()
        {
            return View();
        }
    }
}