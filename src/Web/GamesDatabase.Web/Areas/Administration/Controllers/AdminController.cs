namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AdminController : AdministrationBaseController
    {
        [HttpGet("Administration/")]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}