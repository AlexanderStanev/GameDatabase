using GamesDatabase.Data.Models;
using GamesDatabase.Services.DataServices.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GamesDatabase.Services.DataServices.Services
{
    public class ImageService : IImageService
    {
        public async Task<List<Image>> SaveImageFiles(IEnumerable<IFormFile> mediaFiles, int gameId, string rootPath)
        {
            // TODO: Move to Image service
            var images = new List<Image>();

            var commonPath = $"/images/games/{gameId}";
            var directoryPath = $"{rootPath}/{commonPath}";
            Directory.CreateDirectory(directoryPath);

            var coverImageIsSet = false;
            foreach (var image in mediaFiles)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                var dbImage = new Image()
                {
                    GameId = gameId,
                };

                // TODO: Implement better image type logic
                if (!coverImageIsSet && IsImageIsInPortraitMode(image))
                {
                    dbImage.ImageType = ImageType.Cover;
                    coverImageIsSet = true;
                }
                else
                {
                    dbImage.ImageType = ImageType.Normal;
                }

                dbImage.Path = $"{commonPath}/{dbImage.Id}.{extension}";
                images.Add(dbImage);

                var fullPath = rootPath + dbImage.Path;
                using Stream fileStream = new FileStream(fullPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            return images;
        }

        private bool IsImageIsInPortraitMode(IFormFile file)
        {
            using var image = SixLabors.ImageSharp.Image.Load(file.OpenReadStream());
            if (image.Height > image.Width)
            {
                return true;
            }

            return false;
        }
    }
}
