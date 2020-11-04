﻿using GamesDatabase.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesDatabase.Data.Models
{
    public class ContactForm : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }
    }
}