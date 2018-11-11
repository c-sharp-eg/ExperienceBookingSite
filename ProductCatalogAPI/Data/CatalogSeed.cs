using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public class CatalogSeed
    {
        public static async Task SeedAsync(CatalogContext context)
        {
            context.Database.Migrate();
            if (!context.CatalogLocations.Any())
            {
                context.CatalogLocations.AddRange
                    (GetPreconfiguredCatalogLocations());
                await context.SaveChangesAsync();
            }
            if (!context.CatalogTypes.Any())
            {
                context.CatalogTypes.AddRange
                    (GetPreconfiguredCatalogTypes());
                context.SaveChanges();
            }
            if (!context.CatalogItems.Any())
            {
                context.CatalogItems.AddRange
                    (GetPreconfiguredItems());
                context.SaveChanges();
            }

        }

        static IEnumerable<CatalogLocation> GetPreconfiguredCatalogLocations()
        {
            return new List<CatalogLocation>()
            {
                new CatalogLocation() { Location = "Washington"},
                new CatalogLocation() { Location = "California" },
                new CatalogLocation() { Location = "Illinois" }

            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() { Type = "Concert"},
                new CatalogType() { Type = "Dinner" },
                new CatalogType() { Type = "Social" },

            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem() { CatalogTypeId=1,CatalogLocationId=1, Description = "Beyonce's world tour", Name = "Beyonce Concert", Price = 100, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new CatalogItem() { CatalogTypeId=1,CatalogLocationId=2, Description = "The 20th Coachella", Name = "Coachella", Price= 600, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new CatalogItem() { CatalogTypeId=1,CatalogLocationId=3, Description = "Listen to the world renowed orchestra", Name = "Chicago Symphony Orchestra", Price = 160, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new CatalogItem() { CatalogTypeId=1,CatalogLocationId=1, Description = "Celebrating the 50th year!", Name = "Bumbershoot", Price = 400, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new CatalogItem() { CatalogTypeId=1,CatalogLocationId=2, Description = "Featuring many top artists", Name = "EDM Concert", Price = 300, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new CatalogItem() { CatalogTypeId=1,CatalogLocationId=3, Description = "Smooth Jazz with featured artists", Name = "Jazz Concert", Price = 112, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new CatalogItem() { CatalogTypeId=2,CatalogLocationId=2, Description = "Eat with the writer of your favorite childhood novel", Name = "JK Rowling Dinner", Price = 100, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },
                new CatalogItem() { CatalogTypeId=2,CatalogLocationId=1, Description = "Dinner with Microsoft CEO", Name = "Satya Nadella Dinner", Price = 200, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new CatalogItem() { CatalogTypeId=2,CatalogLocationId=1, Description = "Italian tasting menu", Name = "Staple & Fancy", Price = 75, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new CatalogItem() { CatalogTypeId=2,CatalogLocationId=1, Description = "Omakase by one of Jiro's apprentices", Name = "Sushi Kashiba", Price = 130, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new CatalogItem() { CatalogTypeId=2,CatalogLocationId=3, Description = "Best Pizza in Chicago - tasting menu style", Name = "Giordanos", Price = 50, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new CatalogItem() { CatalogTypeId=3,CatalogLocationId=1, Description = "Bowling Party with 50 strangers", Name = "Bowling Party", Price = 50, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new CatalogItem() { CatalogTypeId=3,CatalogLocationId=2, Description = "Cruise with 100 strangers", Name = "Cruise with Strangers", Price = 100, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new CatalogItem() { CatalogTypeId=3,CatalogLocationId=3, Description = "UCLA alum gathering for class of 2017", Name = "UCLA Class of 2017 Reunion", Price = 25, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14" },
                new CatalogItem() { CatalogTypeId=3,CatalogLocationId=3, Description = "Ice Skating Grand Opening", Name = "Ice Skating", Price = 25, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" }

            };
        }
    }
}
