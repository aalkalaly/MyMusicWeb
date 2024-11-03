using System;
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


        public string Description { get; set; }
        [Required]
       
        public string PublisherId { get; set; } = null!;
        
        public bool IsDeleted { get; set; } = false;
    }
}
