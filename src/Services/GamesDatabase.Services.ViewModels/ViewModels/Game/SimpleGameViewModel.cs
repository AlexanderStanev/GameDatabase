using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;
using System;

namespace GamesDatabase.Web.Models.ViewModels
{
    public class SimpleGameViewModel : IMapFrom<Game>
    {
        public string Title { get; set; }
    }
}