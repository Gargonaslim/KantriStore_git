using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using KantriStore.Models;

namespace KantriStore.Services
{
    public class DataStoreWeb
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public async Task<IEnumerable<Product>> Get(string url)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonSerializer.Deserialize<IEnumerable<Product>>(result, options);
        }

        public async Task<IEnumerable<Auth>> GetAuth(string url)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonSerializer.Deserialize<IEnumerable<Auth>>(result, options);
        }
    }
}
