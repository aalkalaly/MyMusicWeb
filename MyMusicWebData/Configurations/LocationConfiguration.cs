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
            builder.HasData();
        }
       
        
    }
    
}
