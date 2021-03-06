﻿using AutoMapper;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;
using GamesDatabase.Web.Models.ViewModels.Genres;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GamesDatabase.Web.Models.ViewModels.Games
{
    public class SimpleGameViewModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoverImage { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Game, SimpleGameViewModel>()
                .ForMember(vm => vm.CoverImage, opt => opt.MapFrom(g => g.Images.Where(x => x.ImageType == ImageType.Cover).Select(x => x.Path).FirstOrDefault()))
                .ForMember(vm => vm.Genres, opt => opt.MapFrom(g => g.GameGenre.Select(x => x.Genre)));
        }
    }
}
