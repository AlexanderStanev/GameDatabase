using GamesDatabase.Web.Models.InputModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamesDatabase.Web.Models.ViewModels.Games
{
    public class BrowseGameViewModel
    {
        public IEnumerable<SimpleGameViewModel> GamesFound { get; set; }

        //public BrowseSearchParametersGameInputModel SearchParameters { get; set; }

        [Display(Name = "Genres")]
        public int[] GenreIds { get; set; }

        public string Title { get; set; }
    }
}
