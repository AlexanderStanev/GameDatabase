using GamesDatabase.Data.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Interfaces
{
    public interface IImageService
    {
        Task<List<Image>> SaveImageFiles(IEnumerable<IFormFile> mediaFiles, int gameId, string rootPath);
    }
}
