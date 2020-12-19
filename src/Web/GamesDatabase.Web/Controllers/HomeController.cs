namespace GamesDatabase.Web.Controllers
{
    using System.Diagnostics;
    using System.Text;
    using System.Threading.Tasks;
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Services.Messaging;
    using GamesDatabase.Web.Models.InputModels;
    using GamesDatabase.Web.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IContactFormService homeService;
        private readonly IEmailSender emailSender;

        public HomeController(IContactFormService homeService,
            IEmailSender emailSender)
        {
            this.homeService = homeService;
            this.emailSender = emailSender;
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

            var html = new StringBuilder();
            var name = string.IsNullOrEmpty(input.Name) ? "Anonymous" : input.Name;
            html.AppendLine($"<p>{input.Description}</p>");
            await this.emailSender.SendEmailAsync(input.Email, name, "xelaxStanev@gmail.com", input.Title, html.ToString());

            return this.RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
