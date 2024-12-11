using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWeb.Services.Mapping;
using MyMusicWebData.Repository.Interfaces;
using MyMusicWebDataModels;
using MyMusicWebViewModels;
using MyMusicWebViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public async Task AddEventsAsync(EventAddViewModel model)
        {  
            
            var newEvent = new Event
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                LocationId = model.LocationId,
                GenraId = model.GenraId,
                IsActual = true,
                Date = model.Date,
                HealderId = model.HealderId,
                AvailableTickets = model.Count,
                PricePerTicket = model.PricePerTicket
            };
            await eventRepository.AddAsync(newEvent);
        }

        public async Task DeleteFromEventsById(EventDeleteViewModel model)
        {
            Event? events =  eventRepository.GetAllAtached()
                     .Where(p => p.Id == model.Id)
                     .Where(p => p.IsActual == true)
                     .FirstOrDefault();
            if (events != null)
            {
                events.IsActual = false;
                await eventRepository.UpdateAsync(events);
                //await eventRepository.DeleteAsync(events.Id);
            }
        }

        public async Task EditEventsById(EventEditViewModel model, Event entity)
        {
            if (entity == null)
            {
                throw new ArgumentException();
            }
            if(entity.IsActual == false)
            {
                throw new ArgumentException();
            }
            
            if(model.HealderId == entity.HealderId)
            {
                entity.Name = model.Name;
                entity.Date = model.Date;
                entity.Description = model.Description;
                entity.ImageUrl = model.ImageUrl;
                entity.LocationId = model.LocationId;
                entity.GenraId = model.GenraId;
                entity.AvailableTickets = model.Count;
                entity.PricePerTicket = model.PricePerTicket;


                await eventRepository.UpdateAsync(entity);
            }
            


            
        }

        public async Task<EventDetailsViewModel> EventsDetailsById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException();
            }
            var model = await eventRepository
                .GetAllAtached()
                .Where(p => p.Id == id)
                .AsNoTracking()
                .Select(p => new EventDetailsViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Date = p.Date,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    LocationName = p.Location.Name,
                    LocationAdress = p.Location.Adress,
                    GenraName = p.Genra.Name,
                    IsActual = p.IsActual,
                    HealderName = p.Healder.UserName,
                    Count = p.AvailableTickets,
                    PricePerTicket = p.PricePerTicket
                })
                .FirstOrDefaultAsync();
            return model;
        }

        public async Task<int> GetEventsCount(EventPaginationAndSearchViewModel inputModel)
        {
            if (inputModel.SearchQuery != null)
            {
                return await this.eventRepository.GetAllAtached()
                .Where(e => e.IsActual == true)
                .Where(m => m.Name.ToLower().Contains(inputModel.SearchQuery.ToLower()))
                .CountAsync();
            }
            return await this.eventRepository.GetAllAtached().CountAsync();
        }

        public async Task<IEnumerable<EventIndexViewModel>> IndexGetAllActualEventsAsync(EventPaginationAndSearchViewModel inputModel)
        {
            IQueryable<Event> allEventsQuery = this.eventRepository
               .GetAllAtached()
               .Where(e => e.IsActual == true);

            if (!String.IsNullOrWhiteSpace(inputModel.SearchQuery))
            {
                allEventsQuery = allEventsQuery
                    .Where(m => m.Name.ToLower().Contains(inputModel.SearchQuery.ToLower()));
            }

           

            if (inputModel.CurrentPage.HasValue &&
                inputModel.EntitiesPerPage.HasValue)
            {
                allEventsQuery = allEventsQuery
                    .Skip(inputModel.EntitiesPerPage.Value * (inputModel.CurrentPage.Value - 1))
                    .Take(inputModel.EntitiesPerPage.Value);
            }

            return await allEventsQuery
                .Select(p => new EventIndexViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Date = p.Date,
                    ImageUrl = p.ImageUrl,
                    IsActual = p.IsActual,
                    Healder = p.Healder
                })
                .ToArrayAsync();
               
            
            
        }
    }
}
