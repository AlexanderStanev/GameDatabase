using GameDatabase.Data.Core.Repositories;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Mapping;
using GamesDatabase.Web.Models.InputModels;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Services
{
    public class ContactFormService : IContactFormService
    {
        private readonly IDeletableEntityRepository<ContactForm> contactFormsRepository;

        public ContactFormService(IDeletableEntityRepository<ContactForm> contactFormsRepository)
        {
            this.contactFormsRepository = contactFormsRepository;
        }

        public async Task<int> Create(ContactFormInputModel input)
        {
            var contactForm = AutoMapperConfig.MapperInstance.Map<ContactForm>(input);
            await contactFormsRepository.AddAsync(contactForm);
            await contactFormsRepository.SaveChangesAsync();

            return contactForm.Id;
        }
    }
}
