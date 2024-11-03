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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedData());
        }
        public List<Category> SeedData()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Name = "drums"
                },
                new Category()
                {
                    Name = "guitars"
                }
            };
            return categories;
        }
    }
}
