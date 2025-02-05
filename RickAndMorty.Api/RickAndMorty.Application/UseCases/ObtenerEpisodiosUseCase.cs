using RickAndMorty.Domain.Entities;
using RickAndMorty.Domain.Repositories;

namespace RickAndMorty.Application.UseCases
{
    public class ObtenerEpisodiosUseCase
    {
        private readonly IEpisodioRepository _episodioRepository;

        public ObtenerEpisodiosUseCase(IEpisodioRepository episodioRepository)
        {
            _episodioRepository = episodioRepository;
        }

        public async Task<Episodio> BuscarPorId(int id)
        {
            return await _episodioRepository.ObtenerEpisodioPorId(id);
        }

        public async Task<List<Episodio>> BuscarEpisodios(int? pagina)
        {
            if (pagina.HasValue) 
            {
                return await _episodioRepository.ObtenerEpisodios(pagina.Value); 
            }
            else
            {
                return await _episodioRepository.ObtenerEpisodios();
            }
            
        }
    }
}
