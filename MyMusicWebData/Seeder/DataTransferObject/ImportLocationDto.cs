using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MyMusicWeb.Common.EventConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MyMusicWeb.Services.Mapping;
using AutoMapper;
using MyMusicWebDataModels;
using System.Configuration;

namespace MyMusicWebData.Seeder.DataTransferObject
{
    public class ImportLocationDto : IMapTo<MyMusicWebDataModels.Location>, IHaveCustomeMapping
    {
        [Required]
        [MinLength(36)]
        [MaxLength(36)]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(LocationNameMaxLength)]
        [MinLength(LocationNameMinLength)]

        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(LocationAdressMaxLength)]
        [MinLength(LocationAdressMinLength)]
        public string Adress { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<ImportLocationDto, MyMusicWebDataModels.Location>()
               .ForMember(d => d.Id, opt => opt.MapFrom(s => Guid.Parse(s.Id)));
        }
    }
}
