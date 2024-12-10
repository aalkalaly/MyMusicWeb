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
                    Id = Guid.Parse("5f0e2eaf-2a1a-48c2-88a4-ff919b80a8f8"),
                    Name = "drums"
                },
                new Category()
                {
                    Id = Guid.Parse("89c62081-60ac-4385-9ccd-5f67de310137"),
                    Name = "guitars"
                }
            };
            return categories;
        }
    }
}
