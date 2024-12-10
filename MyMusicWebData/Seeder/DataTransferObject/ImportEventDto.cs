using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static MyMusicWeb.Common.EventConstants;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AutoMapper;
using MyMusicWeb.Services.Mapping;
using MyMusicWebDataModels;

namespace MyMusicWebData.Seeder.DataTransferObject
{
    public class ImportEventDto : IMapTo<Event>, IHaveCustomeMapping
    {
        [Required]
        [MinLength(36)]
        [MaxLength(36)]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(EventNameMaxLength)]
        [MinLength(EventNameMinLength)]

        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(EventDescriptionMaxLength)]
        [MinLength(EventDescriptionMinLength)]
        public string Description { get; set; }

        
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        public string GenraId { get; set; }
        [Required]
        public string LocationId { get; set; }

        [Required()]
        public string Date { get; set; }

        [Required]
        [Range(10, 60000)]
        public int Count { get; set; }
        [Required]
        [Range(1, 3000)]
        public decimal PricePerTicket { get; set; }
        [Required]
        public int AvailableTickets { get; set; }
        
         [Required]

        public string HealderId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ImportEventDto, Event>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => Guid.Parse(s.Id)))
                .ForMember(d => d.GenraId, opt => opt.MapFrom(s => Guid.Parse(s.GenraId)))
                .ForMember(d => d.LocationId, opt => opt.MapFrom(s => Guid.Parse(s.LocationId)))
                .ForMember(d => d.Date, opt => opt.MapFrom(s => DateTime.Parse(s.Date)));
        }
    }
}
