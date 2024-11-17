using Microsoft.EntityFrameworkCore;
using MyMusicWebDataModels;
using static MyMusicWeb.Common.EventConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebViewModels.Event
{
    public class EventDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
       
        public string Description { get; set; }
        
        public string? ImageUrl { get; set; }
       
        public DateTime Date { get; set; }
       

        public string GenraName { get; set; }

        
        public string LocationName { get; set; }
        public string LocationAdress { get; set; }

        public bool IsActual { get; set; }
    }
}
