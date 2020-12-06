﻿using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace GamesDatabase.Web.Models.InputModels
{
    public class GameInputModel : IMapTo<Game>, IMapFrom<Game>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(4000)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Announced { get; set; }

        [Required]
        [MaxLength(2048)]
        [Display(Description = "Official Website")]
        public string OfficialWebsite { get; set; }

        [Display(Description = "Upload Media Files")]
        public List<IFormFile> MediaFiles { get; set; }
    }
}