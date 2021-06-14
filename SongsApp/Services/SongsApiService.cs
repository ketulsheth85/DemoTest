using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using SongsApp.Models;

namespace SongsApp.Services
{
    public class SongsApiService : ISongsApiService
    {
        private readonly HttpClient client;

        public SongsApiService(HttpClient CreateClient)
        {
            client = CreateClient;
        }

        public SongsApiService(IHttpClientFactory clientFactory)
        {
            client = clientFactory.CreateClient("PublicSongssApi");
        }
        
        public async Task<List<SongsModel>> GetSongs(int size, string pattern)
        {
            var url = string.Format("/api/songs?size={0}&pattern={1}", size, pattern);
            var result = new List<SongsModel>();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<SongsModel>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
