using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesDatabase.Services.DataServices;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    public class GenreController : AdministrationController
    {
        private readonly IGamesService gamesService;
        private readonly IGenresService genresService;

        public GenreController(IGamesService gamesService, IGenresService genresService)
        {
            this.gamesService = gamesService;
            this.genresService = genresService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenreInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.genresService.Create(input);
            return RedirectToAction("Details", "Genre", new { id = id });
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(GameInputModel game)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return RedirectToAction("Index", "Game");
        }
    }
}
