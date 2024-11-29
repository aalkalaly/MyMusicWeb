using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWebData.Repository.Interfaces;
using MyMusicWebDataModels;
using MyMusicWebViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Services.Data
{
    public class TicketService : ITicketService
    {
        
            private readonly IRepository<Ticket, Guid> ticketRepository;
            private readonly IRepository<Event, object> eventRepository;

            public TicketService(
                IRepository<Ticket, Guid> ticketRepository,
                IRepository<Event, object> eventRepository)
            {
                this.ticketRepository = ticketRepository;
                this.eventRepository = eventRepository;
            }

            public Task<bool> BuyTicketAsync(Guid eventId, Guid userId)
            {
                throw new NotImplementedException();
            }

            public Task<bool> DecreaseAvailableTicketsAsync(Guid eventId, int numberOfTickets)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<UserTicketViewModel>> GetUserTicketsAsync(Guid userId)
            {
                throw new NotImplementedException();
            }

            public Task<bool> SetAvailableTicketsAsync(Guid eventId, int availableTickets)
            {
                throw new NotImplementedException();
            }
        
    }
}
