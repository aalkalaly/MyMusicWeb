using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyMusicWebDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebData.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        void IEntityTypeConfiguration<Location>.Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(SeedData());
        }
        public List<Location> SeedData()
        {
            List<Location> locations = new List<Location>()
            {
                new Location()
                {
                    Name = "Joy Station",
                    Adress = "ж.к. Студентски град, ул. „Акад. Стефан Младенов“ 3, 1700 София"
                },
                new Location()
                {
                    Name = "Vasil Levski Stadium",
                    Adress = "Парк, Борисова Градина, бул. „Евлоги и Христо Георгиеви“ 38, 1164 София"
                },
                new Location()
                {
                    Name = "NDK",
                    Adress = " Ндк, бул. България, 1463 София"
                }
            };
            return locations;
        }
    }
    
}
