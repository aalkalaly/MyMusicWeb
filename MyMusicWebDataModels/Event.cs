using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MyMusicWeb.Common.EventConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyMusicWebDataModels
{
    public class Event
    {
        public Event()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        [Comment("The event's id")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(EventNameMaxLength)]
        [Comment("The event's name")]
        public string Name { get; set; }
        [Required]
        [StringLength(EventDescriptionMaxLength)]
        [Comment("The event's description")]
        public string Description { get; set; }
        [Comment("A photo of the event")]
        public string? ImageUrl { get; set; }
        [Comment("The event's date")]
        public DateTime Date { get; set; }
        [Comment("The event's genra")]

        public Guid GenraId { get; set; }
        public Genra Genra { get; set; }
        [Comment("The event's location")]
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        [Required]
        [Comment("Is the event still ongoing")]
        public bool IsActual { get; set; } = true;
        [Required]

        public int AvailableTickets { get; set; } = 0;

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
