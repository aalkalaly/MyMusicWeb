using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Infrastructure;
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
    public class MusicInstrumentsService : IMusicInstrumentsService
    {
        private IRepository<MusicInstruments, Guid> musicInstrumentRepository;
        public MusicInstrumentsService(IRepository<MusicInstruments, Guid> musicInstrumentRepository)
        {
            this.musicInstrumentRepository = musicInstrumentRepository;
        }

        public Task AddMusicInstrumentsAsync(MusicInstrumentsAddViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFromMusicInstruments(MusicInstrumentsDeleteViewModels model)
        {
            throw new NotImplementedException();
        }

        public Task EditMusicInstrumentsById(MusicInstrumentsEditViewModel model, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MusicalInstrumentsIndexViewModel>> IndexGetAllNotDeletedAsync(string currentUserId)
        {

            var model = await musicInstrumentRepository
                .GetAllAtached()
                .Where(p => p.IsDeleted == false)
                .Select(p => new MusicalInstrumentsIndexViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Seller = p.Seller,
                    HasBought = p.MusicInstrumentsBuyers.Any(p => p.BuyerId == currentUserId)
                })
                .AsNoTracking()
                .ToListAsync();
            return model;
        }

        public Task<MusicInstrumentsDetailsViewModel> MusicInstrumentsDetailsById(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
