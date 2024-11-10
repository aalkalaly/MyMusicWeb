using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebDataModels
{
    public class Genra
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
