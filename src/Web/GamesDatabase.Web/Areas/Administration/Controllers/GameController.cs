using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesDatabase.Services.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    public class GameController : AdministrationController
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GameInputModel game)
        {
            var id = 0;

            return RedirectToAction($"Details/{id}", "Game");
        }

        public IActionResult Edit(int id)
        {
            return View($"Edit/{id}");
        }

        [HttpPost]
        public IActionResult Edit(GameInputModel game)
        {

            var id = 0;
            return RedirectToAction($"Details/{id}", "Game");
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return RedirectToAction("Index", "Game");
        }
    }
}
