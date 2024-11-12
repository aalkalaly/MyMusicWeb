using MyMusicWebDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MyMusicWeb.Common.EventConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebViewModels
{
    public class EventAddViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventLengthMinLength)]
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public Guid GenraId { get; set; }
        public List<Genra>? Genras { get; set; }
        [Required]
        public Guid LocationId { get; set; }
        public List<Genra>? Locations { get; set; }
        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength)]
        public string Description { get; set; }

        public string? SellerId { get; set; } = null!;
    }
}
