using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebViewModels
{
    public class MusicInstrumentsDetailsViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 500)]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
      
        [Required]

        public string CategoryName { get; set; }
        public string Seller { get; set; }
        public bool HasBought { get; set; }
    }
}
