using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebViewModels
{
    public class MusicInstrumentsDeleteViewModels
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string SellerId { get; set; }
        public string Seller { get; set; }
    }
}
