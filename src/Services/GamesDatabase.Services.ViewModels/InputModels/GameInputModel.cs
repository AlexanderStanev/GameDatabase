using GamesDatabase.Data.Models;
using GamesDatabase.Services.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using GamesDatabase.Web.Infrastructure.Attributes;
using Common;
using AutoMapper;
using System.Linq;

namespace GamesDatabase.Web.Models.InputModels
{
    public class GameInputModel : IMapTo<Game>, IMapFrom<Game>, IHaveCustomMappings
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

        [Required]
        public int[] GenreIds { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Released { get; set; }

        [Required]
        [MaxLength(2048)]
        [Display(Name = "Official Website")]
        public string OfficialWebsite { get; set; }

        [Display(Name = "Upload Media Files")]
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { "jpg", "png", "gif" })]
        public List<IFormFile> MediaFiles { get; set; }

        public IEnumerable<SelectListItem> GenreOptions { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Game, GameInputModel>()
                          .ForMember(vm => vm.GenreIds, opt => opt.MapFrom(g => g.GameGenre.Select(x => x.Id)));
        }
    }
}