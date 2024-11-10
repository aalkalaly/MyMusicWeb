using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMusicWeb.Common.CategoryConstants;

namespace MyMusicWebDataModels
{
    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        [Comment("Categorie's Id")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(CategoryNameMaxLength)]
        [Comment("Categorie's Name")]
        public string Name { get; set; }

        public ICollection<MusicInstruments> MusicInstruments { get; set; } = new List<MusicInstruments>();

    }
}
