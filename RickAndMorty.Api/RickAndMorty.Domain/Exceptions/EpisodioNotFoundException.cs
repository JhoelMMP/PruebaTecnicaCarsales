
namespace RickAndMorty.Domain.Exceptions
{
    public class EpisodioNotFoundException : Exception
    {
        public EpisodioNotFoundException(int id) : base($"No se encontró el episodio con el ID: {id}") { }
    }
}
