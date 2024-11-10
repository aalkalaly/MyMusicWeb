using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebDataModels
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Adress { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
