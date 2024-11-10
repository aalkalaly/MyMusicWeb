using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebDataModels
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid GenraId { get; set; }
        public Genra Genra { get; set; }
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        public bool IsActual { get; set; } = true;
    }
}
