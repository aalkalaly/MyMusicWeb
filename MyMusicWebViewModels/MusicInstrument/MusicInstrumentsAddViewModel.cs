using Microsoft.AspNetCore.Identity;
using MyMusicWebDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMusicWeb.Common.MusicInstrumentsConstants;


namespace MyMusicWebViewModels
{
    public class MusicInstrumentsAddViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(MusicInstrumentNameMaxLength , MinimumLength = MusicInstrumentNameMinLength)]
        public string Name { get; set; }
        [Required]
        [Range(typeof(decimal), PriceMinRange, PriceMaxRange)]

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
        [Required]

        public Guid CategoryId { get; set; }

        public List<MyMusicWebDataModels.Category>? Categories { get; set; } 
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLrngth)]
        public string Description { get; set; }

        public string? SellerId { get; set; } = null!;


    }
}
