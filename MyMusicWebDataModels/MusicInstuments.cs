using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyMusicWebDataModels
{
    public class MusicInstuments
    {
        public MusicInstuments()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        [Comment("The Music Instrument's Id")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        [Comment("The Music Instrument's Name")]
        public string Name { get; set; }
        [Required]
        [Comment("The Music Instrument's Price")]
        public decimal Price { get; set; }
        [Comment("The Music Instrument's Image")]
        public string? ImageUrl { get; set; }
        [Required]
        [Comment("The Music Instrument's Category")]
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        [Required]
        [StringLength(500)]
        [Comment("The Music Instrument's Description")]
        public string Description { get; set; }
        //[Required]
        //[Comment("The Id of the Publisher")]
        //public string PublisherId { get; set; } = null!;
        //[ForeignKey(nameof(PublisherId))]
        //public IdentityUser Publisher { get; set; } = null!;

    }
}
