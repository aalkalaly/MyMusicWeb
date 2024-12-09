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

        public CartService(IRepository<MusicInstrumentsBuyers, object> musicInstrumentBuyers, IRepository<MusicInstruments, Guid> musicInstruments, IRepository<Event, Guid> eventsRepository)
        {
            this.musicInstrumentBuyers = musicInstrumentBuyers;
            this.musicInstruments = musicInstruments;
            this.eventsRepository = eventsRepository;
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

        
        public async Task<IEnumerable<EventAddToCart>> CartGetAllNotDeletedEventsAsync(string id)
        {

            var model = await eventsRepository.GetAllAtached()
             .Where(p => p.IsActual == true)
             .Where(g => g.Tickets.Any(t => t.BuyerId == id))
             .Select(p => new EventAddToCart()
             {
                 Id = p.Id,
                 Name = p.Name,
                 ImageUrl = p.ImageUrl,
                 Price = p.Tickets
                 .Where(p => p.BuyerId == id)
                 .Sum(p => p.Price),
                 Count = p.Tickets
                 .Where(p => p.BuyerId == id)
                 .Sum(p => p.Count)
             })
             .AsNoTracking()
             .ToListAsync();
            return model;
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
