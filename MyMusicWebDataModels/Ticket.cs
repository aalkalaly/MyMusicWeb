using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebDataModels
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public string BuyerId { get; set; }
        public IdentityUser User { get; set; }
    }
}
