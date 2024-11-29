using MyMusicWebViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Services.Data.Interfaces
{
    public interface ITicketService
    {
        Task<bool> BuyTicketAsync(Guid eventId, Guid userId);
        Task<bool>SetAvailableTicketsAsync(Guid eventId, int availableTickets);
        Task<bool> DecreaseAvailableTicketsAsync(Guid eventId, int numberOfTickets);
        Task<IEnumerable<UserTicketViewModel>> GetUserTicketsAsync(Guid userId);

    }
}
