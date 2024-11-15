﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MyMusicWeb.Common.EventConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebDataModels
{
    public class Location
    {
        public Location()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        [Comment("The location's id")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(LocationAdressMaxLength)]
        [Comment("The location's adress")]
        public string Adress { get; set; }
        [Required]
        [StringLength(LocationNameMaxLength)]
        [Comment("The location's name")]
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
