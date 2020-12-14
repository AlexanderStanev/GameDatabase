namespace GamesDatabase.Web.Areas.Administration.Controllers
{
    using GamesDatabase.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = Common.GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationBaseController : BaseController
    {
    }
}