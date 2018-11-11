using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        public CatalogService(IOptionsSnapshot<AppSettings> settings,
            IHttpClient httpClient)
        {
            _settings = settings;
            _apiClient = httpClient;
            _remoteServiceBaseUrl = $"{_settings.Value.CatalogUrl}/api/catalog/";

        }

        public async Task<IEnumerable<SelectListItem>> GetLocations()
        {
            var getLocationsUri = ApiPaths.Catalog.GetAllLocations(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(getLocationsUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            var locations = JArray.Parse(dataString);

            foreach (var location in locations.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = location.Value<string>("id"),
                    Text = location.Value<string>("location")
                });
            }

            return items;
        }

        public async Task<Catalog> GetCatalogItems(int page, int take, int? location, int? type)
        {
            var allcatalogItemsUri = ApiPaths.Catalog.GetAllCatalogItems(_remoteServiceBaseUrl, page, take, location, type);

            var dataString = await _apiClient.GetStringAsync(allcatalogItemsUri);

            var response = JsonConvert.DeserializeObject<Catalog>(dataString);

            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypes()
        {
            var getTypesUri = ApiPaths.Catalog.GetAllTypes(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(getTypesUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            var locations = JArray.Parse(dataString);
            foreach (var location in locations.Children<JObject>())
            {
                items.Add(new SelectListItem()
                {
                    Value = location.Value<string>("id"),
                    Text = location.Value<string>("type")
                });
            }
            return items;
        }
    }
}
