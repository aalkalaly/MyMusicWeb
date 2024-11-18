using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MyMusicWeb.Common.EventConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebViewModels.Genra
{
    public class GenraViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(GenraNameMaxLength, MinimumLength = GenraNameMinLength)]
        public string Name { get; set; }
    }
}
