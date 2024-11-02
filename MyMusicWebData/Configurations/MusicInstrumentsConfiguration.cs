using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMusicWebDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebData.Configurations
{
    public class MusicInstrumentsConfiguration : IEntityTypeConfiguration<MusicInstuments>
    {
        void IEntityTypeConfiguration<MusicInstuments>.Configure(EntityTypeBuilder<MusicInstuments> builder)
        {
            
        }
    }
}
