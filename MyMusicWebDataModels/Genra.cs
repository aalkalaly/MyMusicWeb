using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMusicWeb.Common.EventConstants;

namespace MyMusicWebDataModels
{
    public class Genra
    {
        public Genra()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        [Comment("The genra's id")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(GenraNameMaxLength)]
        [Comment("The genra's name")]
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
