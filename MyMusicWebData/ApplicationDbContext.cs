using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMusicWebDataModels;
using System.Reflection;

namespace MyMusicWebData
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected ApplicationDbContext()
        {

        }
        public  DbSet<MusicInstruments> MusicInstruments { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public DbSet<MusicInstrumentsBuyers> MusicInstrumentsBuyers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Genra > Genra { get; set; }
        public DbSet<Location> Location { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
