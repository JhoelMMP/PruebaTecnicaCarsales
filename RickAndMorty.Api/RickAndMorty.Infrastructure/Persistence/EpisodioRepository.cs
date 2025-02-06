using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RickAndMorty.Domain.Entities;
using RickAndMorty.Domain.Repositories;
using RickAndMorty.Infrastructure.Services;


namespace RickAndMorty.Infrastructure.Persistence
{
    public class EpisodioRepository: IEpisodioRepository
    {

        private readonly RickAndMortyApiService _context;

        public EpisodioRepository (RickAndMortyApiService context)
        {
            _context = context;
        }

        public async Task<Paginacion> ObtenerInfoPaginacion()
        {
            return await _context.ObtenerInfoPaginacion();
        }

        public async Task<List<Episodio>> ObtenerEpisodios()
        {
            return await _context.ObtenerEpisodiosDeApi();
        }

        public async Task<Episodio> ObtenerEpisodioPorId(int id)
        {
            return await _context.ObtenerEpisodioDeApi(id);
        }

        public async Task<List<Episodio>> ObtenerEpisodios(int pagina)
        {
            return await _context.ObtenerEpisodiosDeApi(pagina);
        }
    }
}
