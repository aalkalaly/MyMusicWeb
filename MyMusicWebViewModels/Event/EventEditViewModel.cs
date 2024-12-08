using MyMusicWebViewModels.Category;
using MyMusicWebViewModels.Genra;
using MyMusicWebViewModels.Locations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMusicWeb.Common.EventConstants;

namespace MyMusicWebViewModels.Event
{
    public class EventEditViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength)]
        public string Name { get; set; }
        [Required]
        [RegexStringValidator(@"^\d{2}-\d{2}-\d{4}$")]

        public DateTime Date { get; set; }

        public string? ImageUrl { get; set; }

        public Guid GenraId { get; set; }

        public List<GenraViewModel>? Genras { get; set; }
        public Guid LocationId { get; set; }

        public List<LocationViewModel>? Locations { get; set; }
        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength)]
        public string Description { get; set; }
        public string? HealderId { get; set; }

    }
}
