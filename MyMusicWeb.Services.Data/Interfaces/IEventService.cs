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
        Task<IEnumerable<EventIndexViewModel>> IndexGetAllActualEventsAsync(string id);
        Task AddMusicInstrumentsAsync(EventAddViewModel model);
        Task<EventDetailsViewModel> EventsDetailsById(Guid id);
        //Task EditMusicInstrumentsById(MusicInstrumentsEditViewModel model, MusicInstruments entity);
        //Task DeleteFromMusicInstruments(MusicInstrumentsDeleteViewModels model);
    }
}
