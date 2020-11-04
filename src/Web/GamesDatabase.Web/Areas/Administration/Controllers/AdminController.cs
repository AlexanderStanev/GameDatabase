namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AdminController : AdministrationBaseController
    {
        [Route("Administration")]
        public IActionResult Index()
        {
            return this.View("../Index");
        }
    }
}