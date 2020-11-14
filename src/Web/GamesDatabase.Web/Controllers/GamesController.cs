namespace GamesDatabase.Web.Controllers
{
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Web.Models.InputModels;
    using GamesDatabase.Web.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System.Threading.Tasks;

    public class GamesController : BaseController
    {
        private readonly IGamesService gamesService;

        public GamesController(
            IGamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.gamesService.Create(input);
            return this.RedirectToAction("Details", "Games", new { id });
        }

        public IActionResult Edit(int id)
        {
            return this.View($"Edit/{id}");
        }

        [HttpPost]
        public IActionResult Edit(GameInputModel game)
        {
            var id = 0;
            return this.RedirectToAction($"Details/{id}", "Games");
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return this.RedirectToAction(nameof(All));
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