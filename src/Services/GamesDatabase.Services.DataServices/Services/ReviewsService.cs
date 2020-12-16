using GameDatabase.Data.Core.Repositories;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.Mapping;
using GamesDatabase.Web.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IDeletableEntityRepository<Review> reviewsRepository;

        public ReviewsService(IDeletableEntityRepository<Review> reviewsRepository)
        {
            this.reviewsRepository = reviewsRepository;
        }

        public TViewModel GetByUserAndGame<TViewModel>(string currentUserId, int gameId)
        {
            return reviewsRepository.AllAsNoTracking()
                                    .Where(x => x.AuthorId != currentUserId && x.GameId == gameId)
                                    .To<TViewModel>()
                                    .FirstOrDefault();
        }

        public IEnumerable<TViewModel> GetAllExceptForTheGivenUser<TViewModel>(string currentUserId, int page, int itemsPerPage)
        {
            return reviewsRepository.AllAsNoTracking()
                                    .Where(x => x.AuthorId != currentUserId)
                                    .OrderByDescending(x => x.Id)
                                    .Skip((page - 1) * itemsPerPage)
                                    .Take(itemsPerPage)
                                    .To<TViewModel>();
        }

        public double GetAverageRatingOfGame<TViewModel>(int gameId)
        {
            return reviewsRepository.All()
                                    .Where(x => x.GameId == gameId)
                                    .Select(x => x.Rating)
                                    .Average();
        }

        public int? GetIdByUserAndGame(string userId, int gameId)
        {
            return reviewsRepository.AllAsNoTracking().FirstOrDefault(x => x.GameId == gameId && x.AuthorId == userId)?.Id;
        }

        public int GetCount()
        {
            return reviewsRepository.All().Count();
        }

        public async Task Create(ReviewInputModel input)
        {
            var review = AutoMapperConfig.MapperInstance.Map<Review>(input);

            if (reviewsRepository.AllAsNoTracking().Any(x => x.GameId == input.GameId && x.AuthorId == input.AuthorId))
            {
                await Task.FromException<int>(
                      new InvalidOperationException("A review for this user already exists."));
            }

            await reviewsRepository.AddAsync(review);
            await reviewsRepository.SaveChangesAsync();
        }

        public async Task Update(ReviewInputModel input)
        {
            var review = reviewsRepository.AllAsNoTrackingWithDeleted().FirstOrDefault(x => x.Id == input.Id);
            if (review == null)
            {
                throw new InvalidOperationException("The review could not be found");
            }

            review = AutoMapperConfig.MapperInstance.Map<Review>(input);
            review.EditedOn = DateTime.UtcNow;

            reviewsRepository.Update(review);
            await reviewsRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var review = await reviewsRepository.GetByIdWithDeletedAsync(id);
            if (review == null)
            {
                throw new InvalidOperationException("The review could not be found");
            }

            reviewsRepository.Delete(review);
            await reviewsRepository.SaveChangesAsync();
        }
    }
}
