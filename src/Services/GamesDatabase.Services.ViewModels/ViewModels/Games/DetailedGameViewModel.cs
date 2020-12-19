using AutoMapper;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;
using GamesDatabase.Web.Models.ViewModels.Genres;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GamesDatabase.Web.Models.ViewModels.Games
{
    public class DetailedGameViewModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public DateTime? Released { get; set; }

        public string CoverImage { get; set; }

        public string[] Images { get; set; }

        [Display(Name = "Official Website")]
        public string OfficialWebsite { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Game, DetailedGameViewModel>()
                .ForMember(vm => vm.CoverImage, opt => opt.MapFrom(g => g.Images.Where(x => x.ImageType == ImageType.Cover).Select(x => x.Path).FirstOrDefault()))
                .ForMember(vm => vm.Images, opt => opt.MapFrom(g => g.Images.Where(x => x.ImageType == ImageType.Normal).Select(x => x.Path)))

                .ForMember(vm => vm.Genres, opt => opt.MapFrom(g => g.GameGenre.Select(x => x.Genre)));
        }
    }
}