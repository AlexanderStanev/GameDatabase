namespace GamesDatabase.Web.Controllers
{
    using GameDatabase.Data.Common.Repositories;
    using GamesDatabase.Data.Models;
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Web.Models.InputModels;
    using GamesDatabase.Web.Models.ViewModels;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class GamesController : BaseController
    {
        private readonly IDeletableEntityRepository<Game> gamesRepository;
        private readonly IGamesService gamesService;
        private readonly IGenresService genresService;
        private readonly IWebHostEnvironment environment;

        public GamesController(IDeletableEntityRepository<Game> gamesRepository,
            IGamesService gamesService,
            IGenresService genresService,
            IWebHostEnvironment environment)
        {
            this.gamesRepository = gamesRepository;
            this.gamesService = gamesService;
            this.genresService = genresService;
            this.environment = environment;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            var games = gamesService.GetLatestReleasedGames<DetailedGameViewModel>(6);
            return this.View(games);
        }

        public IActionResult All(int page = 1)
        {
            if (page <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;
            var games = gamesService.GetAllGames<SimpleGameViewModel>(page, ItemsPerPage);
            return this.View(games);
        }

        public IActionResult Create()
        {
            var genres = genresService.GetAllGenresAsOptions();
            return this.View(new GameInputModel() { GenreOptions = genres });
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            // Validate images format and size
            var rootPath = this.environment.WebRootPath;

            var id = await this.gamesService.Create(input, rootPath);
            return this.RedirectToAction(nameof(Details), new { id });
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
            return this.RedirectToAction(nameof(Details), new { id });

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            this.gamesService.Delete(id);
            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id)
        {
            var game = this.gamesService.GetGameById<DetailedGameViewModel>(id);
            return this.View(game);
        }

        public IActionResult Search()
        {
            var games = gamesService.GetLatestReleasedGames<DetailedGameViewModel>(6);
            return this.View(games);
        }
    }
}