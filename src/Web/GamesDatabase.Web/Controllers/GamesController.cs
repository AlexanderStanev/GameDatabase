namespace GamesDatabase.Web.Controllers
{
    using GameDatabase.Data.Core.Repositories;
    using GamesDatabase.Data.Models;
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Web.Models.InputModels;
    using GamesDatabase.Web.Models.ViewModels.Games;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
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
            var latestReleasedGames = gamesService.GetLatestReleased<SimpleGameViewModel>(6);
            var randomGames = gamesService.GetRandom<SimpleGameViewModel>(6);

            var indexViewModel = new IndexGameViewModel()
            {
                LatestReleased = latestReleasedGames,
                Random = randomGames,
            };

            return this.View(indexViewModel);
        }

        public IActionResult Browse(BrowseGameViewModel input, int page = 1)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (page <= 0)
            {
                return this.NotFound();
            }

            var games = gamesService.GetAll<SimpleGameViewModel>(input?.Title, input?.GenreIds, page, Common.GlobalConstants.DefaultItemsPerPage);
            input.GamesFound = games;

            return this.View(input);
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

            var rootPath = this.environment.WebRootPath;
            var id = await this.gamesService.Create(input, rootPath);
            return this.RedirectToAction(nameof(Details), new { id });
        }

        public IActionResult Details(int id)
        {
            var game = this.gamesService.GetGameById<DetailedGameViewModel>(id);
            return this.View(game);
        }

        public IActionResult Search()
        {
            var games = gamesService.GetLatestReleased<SimpleGameViewModel>(6);
            return this.View(games);
        }
    }
}