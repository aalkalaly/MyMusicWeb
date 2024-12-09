using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWebData.Repository.Interfaces;
using MyMusicWebDataModels;
using MyMusicWebViewModels;
using MyMusicWebViewModels.Event;
using MyMusicWebViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Services.Data
{
    public class CartService : BaseService, ICartService
    {
        private readonly IRepository<MusicInstrumentsBuyers, object> musicInstrumentBuyers;
        private readonly IRepository<MusicInstruments, Guid> musicInstruments;
        private readonly IRepository<Event, Guid> eventsRepository;
        private readonly IRepository<Ticket, Guid> ticketsRepository;
        public CartService(IRepository<MusicInstrumentsBuyers, object> musicInstrumentBuyers, IRepository<MusicInstruments, Guid> musicInstruments)
        {
            this.musicInstrumentBuyers = musicInstrumentBuyers;
            this.musicInstruments = musicInstruments;
        }

       

        public async Task AddInstrumentsToCartById(Guid id, string currentUserId)
        {

            MusicInstruments? entity =  musicInstruments.GetAllAtached()
                 .Where(p => p.Id == id)
                 .Include(p => p.MusicInstrumentsBuyers)
                 .FirstOrDefault();
            if (entity == null)
                    {
                        throw new ArgumentException();
                    }
            if (entity.MusicInstrumentsBuyers.Any(pc => pc.BuyerId == currentUserId))
            {
                throw new ArgumentException();
            }
            
            entity.MusicInstrumentsBuyers.Add(new MusicInstrumentsBuyers()
            {
                BuyerId = currentUserId,
                MusicInstrumentId = entity.Id,
            });
            
            await musicInstruments.UpdateAsync(entity);
        }

        public Task BuyTickets(BuyTicketViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EventIndexViewModel>> CartGetAllNotDeletedEventsAsync(string id)
        {
            throw new NotImplementedException();
            //var model = await eventsRepository.GetAllAtached()
            // .Where(p => p.IsActual  == true)
            // .Where(g => g.Tickets.Any(t => t.BuyerId == id))
            // .Select(p => new EventAddToCart()
            // {
            //     Id = p.Id,
            //     Name = p.Name,
            //     ImageUrl = p.ImageUrl,
            //     Tickets = p.Tickets
            //     .Where(p => p.BuyerId == id)
            //     .Select(p => new BuyTicketViewModel
            //     {

            //     })
            //     .ToList(),
            //     Count = 
            // })
            // .AsNoTracking()
            // .ToListAsync();
            //return model;
        }

        public async Task<IEnumerable<MusicalInstrumentsIndexViewModel>> CartGetAllNotDeletedInstrumentsAsync(string id)
        {

                  var model = await musicInstruments.GetAllAtached()
             .Where(p => p.IsDeleted == false)
             .Where(g => g.MusicInstrumentsBuyers.Any(cl => cl.BuyerId == id))
             .Select(p => new MusicalInstrumentsIndexViewModel()
             {
                  Id = p.Id,
                  Name = p.Name,
                  ImageUrl = p.ImageUrl,
                  Price = p.Price,
                  Seller = p.Seller,
             })
             .AsNoTracking()
             .ToListAsync();
            return model;
        }

        public Task RemoveEventsFromCartById(Guid id, string currentUserId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveInstrumentsFromCartById(Guid id, string currentUserId)
        {
            
            MusicInstruments? entity = await musicInstruments.GetAllAtached()
                .Where(p => p.Id == id)
                .Include(p => p.MusicInstrumentsBuyers)
                .FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new ArgumentException();
            }
            
            MusicInstrumentsBuyers? productClient = entity.MusicInstrumentsBuyers.FirstOrDefault(pc => pc.BuyerId == currentUserId);
            if (productClient != null)
            {
                entity.MusicInstrumentsBuyers.Remove(productClient);
                await musicInstruments.UpdateAsync(entity);
            }
        }
    }
}
