using MyMusicWebViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Services.Data.Interfaces
{
    public interface IMusicInstrumentsService
    {
        Task<IEnumerable<MusicalInstrumentsIndexViewModel>> IndexGetAllNotDeletedAsync(string id);
        Task AddMusicInstrumentsAsync(MusicInstrumentsAddViewModel model);
        Task<MusicInstrumentsDetailsViewModel> MusicInstrumentsDetailsById(Guid id);
        Task EditMusicInstrumentsById(MusicInstrumentsEditViewModel model, Guid id);
        Task DeleteFromMusicInstruments(MusicInstrumentsDeleteViewModels model);

    }
}
