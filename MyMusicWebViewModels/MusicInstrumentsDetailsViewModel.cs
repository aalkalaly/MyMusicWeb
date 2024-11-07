using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMusicWeb.Common.MusicInstrumentsConstants;


namespace MyMusicWebViewModels
{
    public class MusicInstrumentsDetailsViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(MusicInstrumentNameMaxLength, MinimumLength = MusicInstrumentNameMinLength)]
        public string Name { get; set; }
        [Required]
        [Range(typeof(decimal), PriceMinRange, PriceMaxRange)]
        public decimal Price { get; set; }
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength =DescriptionMinLrngth)]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
      
        [Required]

        public string CategoryName { get; set; }
        public string Seller { get; set; }
        public bool HasBought { get; set; }
    }
}
