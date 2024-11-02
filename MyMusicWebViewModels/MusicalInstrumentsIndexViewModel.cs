using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebViewModels
{
    public class MusicalInstrumentsIndexViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public Guid CategoryId { get; set; }

        //public Category Category { get; set; }

        public string Description { get; set; }
        //[Required]
        //[Comment("The Id of the Publisher")]
        //public string PublisherId { get; set; } = null!;
        //[ForeignKey(nameof(PublisherId))]
        //public IdentityUser Publisher { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
    }
}
