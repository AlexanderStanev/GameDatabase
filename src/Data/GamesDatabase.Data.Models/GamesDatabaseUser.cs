using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesDatabase.Data.Models
{
    public class GamesDatabaseUser : IdentityUser
    {
        public IEnumerable<Review> Reviews { get; set; }

        //public IEnumerable<GamesDatabaseUser> Friends { get; set; }
    }
}
