﻿using Microsoft.AspNetCore.Identity;
using MyMusicWebViewModels.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebViewModels.Event
{
    public class EventAddToCart
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public List<BuyTicketViewModel> Tickets { get; set; }
        public int Count { get; set; }
    }
}