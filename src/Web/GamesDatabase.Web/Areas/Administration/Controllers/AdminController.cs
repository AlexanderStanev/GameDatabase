using Microsoft.AspNetCore.Mvc;

namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    public class AdminController : AdministrationBaseController
    {
        [Route("Administration")]
        public IActionResult Index()
        {
            return View("../Index");
        }
    }
}