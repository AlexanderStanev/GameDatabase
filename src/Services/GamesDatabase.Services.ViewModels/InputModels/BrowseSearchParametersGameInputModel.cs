using System;
using System.Collections.Generic;
using System.Text;

namespace GamesDatabase.Web.Models.InputModels
{
    public class BrowseSearchParametersGameInputModel
    {
        public int[] GenreIds { get; set; }

        public string Title { get; set; }
    }
}
