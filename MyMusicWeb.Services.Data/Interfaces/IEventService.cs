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
        Task<IEnumerable<EventIndexViewModel>> IndexGetAllActualEventsAsync( Organisation entity);
        Task AddEventsAsync(EventAddViewModel model);
        Task<EventDetailsViewModel> EventsDetailsById(Guid id, Organisation currentUser);
        Task EditEventsById(EventEditViewModel model, Event entity);
        Task DeleteFromEventsById(EventDeleteViewModel model);
    }
}
