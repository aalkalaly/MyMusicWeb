using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebDataModels
{
    [PrimaryKey(nameof(MusicInstrumentId), nameof(BuyerId))]
    public class MusicInstrumentsBuyers
    {
        public Guid MusicInstrumentId { get; set; }
        [ForeignKey(nameof(MusicInstrumentId))]
        public MusicInstruments MusicInstruments { get; set; }
        public string BuyerId { get; set; }
        [ForeignKey(nameof(BuyerId))]
        public IdentityUser Buyer { get; set; }

    }
}
