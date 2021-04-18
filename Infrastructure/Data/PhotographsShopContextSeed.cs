using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class PhotographsShopContextSeed
    {
        public static async Task SeedAsync(PhotographsShopContext photographsShopContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!photographsShopContext.PhotographLocations.Any())
                {
                    var locationsData = File.ReadAllText("../Infrastructure/Data/SeedData/locations.json");
                    var locations = JsonSerializer.Deserialize<List<PhotographLocation>>(locationsData);
                    foreach (var location in locations)
                    {
                        photographsShopContext.PhotographLocations.Add(location);
                    }
                    await photographsShopContext.SaveChangesAsync();
                }
                if (!photographsShopContext.Photographs.Any())
                {
                    var photographsData = File.ReadAllText("../Infrastructure/Data/SeedData/photographs.json");
                    var photographs = JsonSerializer.Deserialize<List<Photograph>>(photographsData);
                    foreach (var photograph in photographs)
                    {
                        photographsShopContext.Photographs.Add(photograph);
                    }
                    await photographsShopContext.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<PhotographsShopContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}