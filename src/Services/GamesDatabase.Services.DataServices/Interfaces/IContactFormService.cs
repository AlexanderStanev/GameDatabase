using GamesDatabase.Web.Models.InputModels;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IContactFormService
    {
        Task<int> Create(ContactFormInputModel input);
    }
}
