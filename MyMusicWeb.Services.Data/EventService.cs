﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWebData.Repository.Interfaces;
using MyMusicWebDataModels;
using MyMusicWebViewModels;
using MyMusicWebViewModels.Event;
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
            Event? events = await eventRepository.GetAllAtached()
                     .Where(p => p.Id == model.Id)
                     .Where(p => p.IsActual == true)
                     .FirstOrDefaultAsync();
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

        public async Task<IEnumerable<EventIndexViewModel>> IndexGetAllActualEventsAsync(string userId)
        {
            var model = await eventRepository
                .GetAllAtached()
               .Where(p => p.IsActual == true)
               .Select(p => new EventIndexViewModel()
               {
                   Id = p.Id,
                   Name = p.Name,
                   Date = p.Date,
                   ImageUrl = p.ImageUrl,
                   IsActual = p.IsActual,
                   Healder = p.Healder
               })
               .AsNoTracking()
               .ToListAsync();
            return model;
        }
    }
}
