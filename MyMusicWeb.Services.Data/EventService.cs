using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWebData.Repository.Interfaces;
using MyMusicWebDataModels;
using MyMusicWebViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Services.Data
{
    public class EventService : IEventService
    {
        private IRepository<Event, Guid> eventRepository;
        public EventService(IRepository<Event, Guid> eventRepository)
        {
            this.eventRepository = eventRepository;
        }
        public async Task AddMusicInstrumentsAsync(EventAddViewModel model)
        {
            var newEvent = new Event
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                LocationId = model.LocationId,
                GenraId = model.GenraId,
                IsActual = true,
                Date = model.Date
            };
            await eventRepository.AddAsync(newEvent);
        }

        public async Task<IEnumerable<EventIndexViewModel>> IndexGetAllActualEventsAsync(string id)
        {
            var model = await eventRepository
                .GetAllAtached()
               .Where(p => p.IsActual != false)
               .Select(p => new EventIndexViewModel()
               {
                   Id = p.Id,
                   Name = p.Name,
                   Date = p.Date,
                   ImageUrl = p.ImageUrl,
                   IsActual = p.IsActual
               })
               .AsNoTracking()
               .ToListAsync();
            return model;
        }
    }
}
