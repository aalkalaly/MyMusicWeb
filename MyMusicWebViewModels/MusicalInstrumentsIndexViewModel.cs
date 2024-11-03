using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMusicWebDataModels;

namespace MyMusicWebViewModels
{
    public class MusicalInstrumentsIndexViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public Guid CategoryId { get; set; }

        public IdentityUser Seller { get; set; } = null!;
        public bool HasBought { get; set; }

    }
}
