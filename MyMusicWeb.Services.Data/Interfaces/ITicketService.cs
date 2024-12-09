using MyMusicWebViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Services.Data.Interfaces
{
    public interface ITicketService
    {
        Task<bool> BuyTicketAsync( BuyTicketViewModel model);


    }
}
