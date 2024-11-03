﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        [Required]
        public string SellerId { get; set; }
        [ForeignKey(nameof(SellerId))]
        public IdentityUser Seller { get; set; }
        [Required]
        [Comment("Is the Instrument Deleted")]
        public bool IsDeleted { get; set; } = false;
        public ICollection<MusicInstrumentsBuyers> MusicInstrumentsBuyers { get; set; } = new List<MusicInstrumentsBuyers>();
       

    }
}
