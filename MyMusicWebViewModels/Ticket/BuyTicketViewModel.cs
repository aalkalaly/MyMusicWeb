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
        [Required]
        public Guid EventId { get; set; }
        [Required]
        [Range(typeof(decimal), MinPriceForTicket, MaxPriceForTicket)]
        public decimal Price { get; set; }
        [Required]
        [Range(MinCountOfTickets, MaxCountOfTickets)]
        public int Count { get; set; }
    }
}
