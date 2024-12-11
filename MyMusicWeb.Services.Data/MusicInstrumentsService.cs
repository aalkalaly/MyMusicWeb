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

        public async Task AddMusicInstrumentsAsync(MusicInstrumentsAddViewModel model)
        {
            var newInstrument = new MusicInstruments
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                SellerId = model.SellerId
            };
            await musicInstrumentRepository.AddAsync(newInstrument);
        }

        public async Task DeleteFromMusicInstruments(MusicInstrumentsDeleteViewModels model)
        {
            MusicInstruments? instrument = await musicInstrumentRepository.GetAllAtached()
                .Where(p => p.Id == model.Id)
                .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (instrument != null)
            {
                instrument.IsDeleted = true;
                await musicInstrumentRepository.UpdateAsync(instrument);
                //await musicInstrumentRepository.DeleteAsync(instrument.Id);
            }
        }

        public async Task EditMusicInstrumentsById(MusicInstrumentsEditViewModel model, MusicInstruments entity)
        {
           
            if (entity == null)
            {
                throw new ArgumentException();
            }

            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.CategoryId = model.CategoryId;
            entity.SellerId = model.SellerId;


            await musicInstrumentRepository.UpdateAsync(entity);
            
        }

        public async Task<IEnumerable<MusicalInstrumentsIndexViewModel>> IndexGetAllNotDeletedAsync(string currentUserId)
        {
            if(currentUserId == null)
            {
                return null;
            }
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

        public async Task<MusicInstrumentsDetailsViewModel> MusicInstrumentsDetailsById(Guid id)
        {
            var model = await musicInstrumentRepository
                .GetAllAtached()
                .Where(p => p.Id == id)
                .AsNoTracking()
                .Select(p => new MusicInstrumentsDetailsViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category.Name,
                    Seller = p.Seller.UserName,
                    HasBought = p.MusicInstrumentsBuyers.Any(p => p.MusicInstrumentId == id)

                })
                .FirstOrDefaultAsync();
            return model;
        }

    }
}
