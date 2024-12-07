using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MyMusicWeb.Common.EventConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebDataModels
{
    public class Organisation : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(OrgnisationNameMaxLength)]
        [Comment("name of the organisation")]
        public string OrganisationName { get; set; }
        public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();
    }
}
