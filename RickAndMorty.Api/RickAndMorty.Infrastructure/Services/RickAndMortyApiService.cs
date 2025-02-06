using Newtonsoft.Json.Linq;
using RickAndMorty.Domain.Entities;
using RickAndMorty.Api.Configurations;
using Microsoft.Extensions.Options;

namespace RickAndMorty.Infrastructure.Services
{
    public class RickAndMortyApiService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public RickAndMortyApiService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }

        public async Task<Paginacion> ObtenerInfoPaginacion()
        {
            var response = await _httpClient.GetAsync($"{_appSettings.RickAndMortyApiUrl}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);
                var results = data["info"].ToObject<Paginacion>();
                return results;
            }
            return null;
        }

        public async Task<List<Episodio>> ObtenerEpisodiosDeApi()
        {
            var response = await _httpClient.GetAsync($"{_appSettings.RickAndMortyApiUrl}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);
                var results = data["results"].ToObject<List<Episodio>>();
                return results;
            }
            return null;
        }

        public async Task<Episodio> ObtenerEpisodioDeApi(int id)
        {
            var response = await _httpClient.GetAsync($"{_appSettings.RickAndMortyApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);
                var results = data.ToObject<Episodio>();
                return results;
            }
            return null;
        }

        public async Task<List<Episodio>> ObtenerEpisodiosDeApi(int pagina)
        {
            var response = await _httpClient.GetAsync($"{_appSettings.RickAndMortyApiUrl}?page={pagina}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);
                var results = data["results"].ToObject<List<Episodio>>();
                return results;
            }
            return null;
        }
    }
}
