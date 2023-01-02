using System;
using MCVWebApp.Models;
using Newtonsoft.Json;

namespace MCVWebApp.Services
{
	public interface ICatalogService
	{
		Task<IEnumerable<CatalogItem>> GetAllCatalogItems();
		Task<CatalogItem> GetCatalogItemDetails(int id);
    }

    public class CatalogService : ICatalogService
    {
        string _remoteServiceBaseUrl;
        public CatalogService(IConfiguration config)
        {
            _remoteServiceBaseUrl = config["CatalogUrl"];
        }

        public async Task<IEnumerable<CatalogItem>> GetAllCatalogItems()
        {
            var client = new HttpClient();
            var result = await client.GetAsync(_remoteServiceBaseUrl + "/CatalogItems/");
            result.EnsureSuccessStatusCode();
            var dataString = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<CatalogItem>>(dataString);
        }

        public async Task<CatalogItem> GetCatalogItemDetails(int id)
        {
            var client = new HttpClient();
            var result = await client.GetAsync(_remoteServiceBaseUrl + "/CatalogItems/" + id);
            result.EnsureSuccessStatusCode();

            CatalogItem item = JsonConvert.DeserializeObject<CatalogItem>(await result.Content.ReadAsStringAsync());

            return item;
        }
    }
}

