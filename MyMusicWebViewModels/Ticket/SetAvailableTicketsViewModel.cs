using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMusicWeb.Common.TicketConstants;

namespace MyMusicWebViewModels.Ticket
{
    public class SetAvailableTicketsViewModel
    {
        [Required]
        public string EventId { get; set; }
        [Required(ErrorMessage = "Please Enter the number of available tickets")]
        [Range(MinAvailableTicketsCount, MaxAvailableTicketsCount)]
        public int AvailableTicketsCount { get; set; }
    }
    
}
