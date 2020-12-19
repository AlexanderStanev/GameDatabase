using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Web.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    public class GamesController : AdministrationBaseController
    {
        private IGamesService gamesService;

        public GamesController(IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IActionResult Edit(int id)
        {
            var game = this.gamesService.GetGameById<GameInputModel>(id);
            return this.View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.gamesService.Update(input);
            return this.RedirectToAction("Details", new { area = "", id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.gamesService.Delete(id);
            return this.RedirectToAction("Browse", new { area = "" });
        }
    }
}
