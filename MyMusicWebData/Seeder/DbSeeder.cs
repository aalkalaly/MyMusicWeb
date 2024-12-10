using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyMusicWeb.Services.Mapping;
using MyMusicWebData.Seeder.DataTransferObject;
using MyMusicWebDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyMusicWebData.Seeder
{
    public static class DbSeeder
    {
        
        public static async Task SeedEventAsync(IServiceProvider services, string jsonPathEvent, string jsonPathGenra, string jsonPathLocation)
        {
            using ApplicationDbContext dbContext = services.GetRequiredService<ApplicationDbContext>();
            try
            {
                string jsonInput = await File.ReadAllTextAsync(jsonPathGenra, Encoding.ASCII, CancellationToken.None);
                ImportGenraDto[] genraDtos = JsonSerializer.Deserialize<ImportGenraDto[]>(jsonInput);
                foreach (var dto in genraDtos)
                {
                    if (dbContext.Genra.FirstOrDefault(g => g.Id == Guid.Parse(dto.Id)) == null)
                    {
                        Genra genra = AutoMapperConfig.MapperInstance.Map<Genra>(dto);
                        await dbContext.Genra.AddAsync(genra);
                    }

                }
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            try
            {
                string jsonInput = await File.ReadAllTextAsync(jsonPathLocation, Encoding.ASCII, CancellationToken.None);
                ImportLocationDto[] locationDtos = JsonSerializer.Deserialize<ImportLocationDto[]>(jsonInput);
                foreach (var dto in locationDtos)
                {
                    if (dbContext.Location.FirstOrDefault(g => g.Id == Guid.Parse(dto.Id)) == null)
                    {
                        Location location = AutoMapperConfig.MapperInstance.Map<Location>(dto);
                        await dbContext.Location.AddAsync(location);
                    }
                    
                }
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            try
            {
                string jsonInput = await File.ReadAllTextAsync(jsonPathEvent, Encoding.ASCII, CancellationToken.None);
                ImportEventDto[] eventDtos = JsonSerializer.Deserialize<ImportEventDto[]>(jsonInput);
                foreach(var dto in eventDtos)
                {
                    if (dbContext.Events.FirstOrDefault(g => g.Id == Guid.Parse(dto.Id)) == null)
                    {
                        Event events = AutoMapperConfig.MapperInstance.Map<Event>(dto);
                        events.Location = dbContext.Location.FirstOrDefault(l => l.Id == events.LocationId);
                        events.Genra = dbContext.Genra.FirstOrDefault(g => g.Id == events.GenraId);

                        await dbContext.Events.AddAsync(events);
                    }
                    
                }
                await dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
       
    }
}
