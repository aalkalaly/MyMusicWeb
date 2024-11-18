using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using static MyMusicWeb.Common.EventConstants;
using System.Threading.Tasks;

namespace MyMusicWebViewModels.Locations
{
    public class LocationViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(LocationNameMaxLength, MinimumLength = LocationNameMinLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(LocationAdressMaxLength, MinimumLength = LocationAdressMinLength)]
        public string Adress { get; set; }
    }
}
