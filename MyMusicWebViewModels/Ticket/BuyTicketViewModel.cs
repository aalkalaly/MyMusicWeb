using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMusicWeb.Common.TicketConstants;

namespace MyMusicWebViewModels.Ticket
{
    public class BuyTicketViewModel
    {
 
        public Guid EventId { get; set; }

 
        [Required]
        [Range(MinCountOfTickets, MaxCountOfTickets, ErrorMessage = "Pick a number between 1 and 20")]
        public int Count { get; set; }
        public string? BuyerId { get; set; }
    }
}
