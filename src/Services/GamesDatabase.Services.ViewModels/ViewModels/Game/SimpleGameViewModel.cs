using System;
using System.Collections.Generic;
using AutoMapper;
using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;

namespace GamesDatabase.Services.Models.ViewModels
{
    public class SimpleGameViewModel : IMapFrom<Game>
    {
        public string Title { get; set; }

        public double Raiting { get; set; }

        public int ReviewsCount { get; set; }

        public string Genre { get; set; }

        public DateTime DateReleased { get; set; }

        public string Developer { get; set; }
    }
}