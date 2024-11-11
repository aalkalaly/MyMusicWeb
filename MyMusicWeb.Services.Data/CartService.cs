﻿using Microsoft.EntityFrameworkCore;
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
    public class CartService : ICartService
    {
        private readonly IRepository<MusicInstrumentsBuyers, object> musicInstrumentBuyers;
        private readonly IRepository<MusicInstruments, Guid> musicInstruments;
        public CartService(IRepository<MusicInstrumentsBuyers, object> musicInstrumentBuyers, IRepository<MusicInstruments, Guid> musicInstruments)
        {
            this.musicInstrumentBuyers = musicInstrumentBuyers;
            this.musicInstruments = musicInstruments;
        }
        public Task AddToCartById()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MusicalInstrumentsIndexViewModel>> CartGetAllNotDeletedAsync(string id)
        {

                  var model = await musicInstruments.GetAllAtached()
             .Where(p => p.IsDeleted == false)
             .Where(g => g.MusicInstrumentsBuyers.Any(cl => cl.BuyerId == id))
             .Select(p => new MusicalInstrumentsIndexViewModel()
             {
                  Id = p.Id,
                  Name = p.Name,
                  ImageUrl = p.ImageUrl,
                  Price = p.Price,
                  Seller = p.Seller,
             })
             .AsNoTracking()
             .ToListAsync();
            return model;
        }

        public Task RemoveFromCartById()
        {
            throw new NotImplementedException();
        }
    }
}
