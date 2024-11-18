using MyMusicWebViewModels;
using MyMusicWebViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Services.Data.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<MusicalInstrumentsIndexViewModel>> CartGetAllNotDeletedInstrumentsAsync(string id);
        Task RemoveInstrumentsFromCartById(Guid id, string currentUserId);
        Task AddInstrumentsToCartById(Guid id, string currentUserId);
        Task<IEnumerable<EventIndexViewModel>> CartGetAllNotDeletedEventsAsync(string id);
        Task RemoveEventsFromCartById(Guid id, string currentUserId);
        Task AddEventsToCartById(Guid id, string currentUserId);
    }
}
