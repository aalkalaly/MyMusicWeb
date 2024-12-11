using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebViewModels.Event
{
    public class EventPaginationAndSearchViewModel
    {
        public IEnumerable<EventIndexViewModel>? Events { get; set; }

        public string? SearchQuery { get; set; }

        public int? CurrentPage { get; set; } = 1;

        public int? EntitiesPerPage { get; set; } = 4;

        public int? TotalPages { get; set; }
    }
}
