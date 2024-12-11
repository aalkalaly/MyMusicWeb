using MyMusicWebDataModels;
using MyMusicWebViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Services.Data.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventIndexViewModel>> IndexGetAllActualEventsAsync(EventPaginationAndSearchViewModel inputModel);
        Task AddEventsAsync(EventAddViewModel model);
        Task<EventDetailsViewModel> EventsDetailsById(Guid id);
        Task EditEventsById(EventEditViewModel model, Event entity);
        Task DeleteFromEventsById(EventDeleteViewModel model);
        Task <int> GetEventsCount(EventPaginationAndSearchViewModel inputModel);
    }
}
