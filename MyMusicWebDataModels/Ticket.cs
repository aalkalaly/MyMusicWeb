using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebDataModels
{
    public class Ticket
    {
        [Key]
        [Comment("the ticket's Id")]
        public Guid Id { get; set; }
        [Required]
        [Comment("the ticket's Id")]
        public decimal Price { get; set; }
        [Comment("the event that this ticket is for")]
        public Guid EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; }
        [Comment("the person who bought the ticket")]
        public string BuyerId { get; set; }
        [ForeignKey(nameof(BuyerId))]
        public IdentityUser Buyer { get; set; }
    }
}
