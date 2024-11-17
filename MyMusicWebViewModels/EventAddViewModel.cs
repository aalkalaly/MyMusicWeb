using MyMusicWebDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MyMusicWeb.Common.EventConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MyMusicWebViewModels
{
    public class EventAddViewModel
    {
        [Required]
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
        public List<Location>? Locations { get; set; }
        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength)]
        public string Description { get; set; }
        [Required(ErrorMessage = "No Date Provided")]
        [RegexStringValidator(@"^\d{2}-\d{2}-\d{4}$")]
        public DateTime Date { get; set; }

    }
}
