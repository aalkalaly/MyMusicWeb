﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyMusicWebDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebViewModels.Event
{
    public class EventIndexViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActual { get; set; } = true;
        public  IdentityUser Healder { get; set; }
        public int TotalPages { get; set; }
    }
}
