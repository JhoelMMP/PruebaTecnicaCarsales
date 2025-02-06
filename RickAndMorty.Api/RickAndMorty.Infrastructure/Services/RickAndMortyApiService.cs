using Newtonsoft.Json.Linq;
using RickAndMorty.Domain.Entities;

namespace RickAndMorty.Infrastructure.Services
{
    public class RickAndMortyApiService
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Paginacion> ObtenerInfoPaginacion()
        {
            var response = await _httpClient.GetAsync($"https://rickandmortyapi.com/api/episode");
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
            var response = await _httpClient.GetAsync($"https://rickandmortyapi.com/api/episode");
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
            var response = await _httpClient.GetAsync($"https://rickandmortyapi.com/api/episode/{id}");
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
            var response = await _httpClient.GetAsync($"https://rickandmortyapi.com/api/episode?page={pagina}");
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
