using System;
using System.Collections.Generic;
using System.Text;

namespace GamesDatabase.Web.Models.ViewModels.Games
{
    public class IndexGameViewModel
    {
        public IEnumerable<SimpleGameViewModel> LatestReleased { get; set; }

        public IEnumerable<SimpleGameViewModel> Random { get; set; }
    }
}
