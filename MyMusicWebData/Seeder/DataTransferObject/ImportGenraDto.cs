using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MyMusicWeb.Common.EventConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMusicWeb.Services.Mapping;
using MyMusicWebDataModels;
using AutoMapper;
using System.Configuration;

namespace MyMusicWebData.Seeder.DataTransferObject
{
    public class ImportGenraDto : IMapTo<Genra>, IHaveCustomeMapping
    {
        [Required]
        [MinLength(36)]
        [MaxLength(36)]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(GenraNameMaxLength)]
        [MinLength(GenraNameMinLength)]

        public string Name { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<ImportGenraDto, Genra>()
               .ForMember(d => d.Id, opt => opt.MapFrom(s => Guid.Parse(s.Id)));
        }
    }
}
