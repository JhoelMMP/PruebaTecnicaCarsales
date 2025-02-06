using RickAndMorty.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Domain.Repositories
{
    public interface IEpisodioRepository
    {
        Task<Paginacion> ObtenerInfoPaginacion();

        Task<List<Episodio>> ObtenerEpisodios();

        Task<List<Episodio>> ObtenerEpisodios(int pagina);

        Task<Episodio> ObtenerEpisodioPorId(int id);
    }
}
