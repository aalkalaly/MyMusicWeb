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
    public class GenraConfiguration : IEntityTypeConfiguration<Genra>
    {
        void IEntityTypeConfiguration<Genra>.Configure(EntityTypeBuilder<Genra> builder)
        {
            builder.HasData(SeedData());
        }
        public List<Genra > SeedData()
        {
            List<Genra> genras = new List<Genra>()
            {
                new Genra()
                {
                    Name = "jazz"
                },
                new Genra()
                {
                    Name = "rock"
                },
                new Genra()
                {
                    Name = "metal"
                },
                new Genra()
                {
                    Name = "rap"
                }
            };
            return genras;

        }
    
    }
}
