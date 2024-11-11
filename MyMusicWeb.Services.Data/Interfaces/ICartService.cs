using MyMusicWebViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Services.Data.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<MusicalInstrumentsIndexViewModel>> CartGetAllNotDeletedAsync(string id);
        Task RemoveFromCartById();
        Task AddToCartById(Guid id, string currentUserId);
    }
}
