namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    using GamesDatabase.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    [Area("Administration")]
    public class AdministrationBaseController : BaseController
    {
    }
}