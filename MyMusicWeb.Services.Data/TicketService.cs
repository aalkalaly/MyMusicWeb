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
            private readonly IRepository<Event, Guid> eventRepository;

            public TicketService(
                IRepository<Ticket, Guid> ticketRepository,
                IRepository<Event, Guid> eventRepository)
            {
                this.ticketRepository = ticketRepository;
                this.eventRepository = eventRepository;
            }

        public async Task<bool> BuyTicketAsync(  BuyTicketViewModel model)
        {
            Event? eventOrNull = await eventRepository.FirstOrDefaultAsync(p => p.Id == model.EventId);
            if (eventOrNull == null  )
            {
                return false;
            }
            if (!eventOrNull.IsActual)
            {
                return false;
            }
            var newTicket = new Ticket
            {
                EventId = model.EventId,
                BuyerId = model.BuyerId,
                Count = model.Count,
                Price = eventRepository.GetById(model.EventId).PricePerTicket * model.Count
            };
            await ticketRepository.AddAsync(newTicket);
            return true;
        }

          
        
    }
}
