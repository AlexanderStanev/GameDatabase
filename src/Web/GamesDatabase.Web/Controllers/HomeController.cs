namespace GamesDatabase.Web.Controllers
{
    using System.Diagnostics;
    using GamesDatabase.Web.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.Redirect("/Games/All");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
