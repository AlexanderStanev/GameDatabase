namespace GamesDatabase.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Web.Models.InputModels;
    using GamesDatabase.Web.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private IContactFormService homeService;

        public HomeController(IContactFormService homeService)
        {
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction(nameof(GamesController.Index));
        }

        public IActionResult Contact()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var id = await this.homeService.Create(input);
            return this.RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
