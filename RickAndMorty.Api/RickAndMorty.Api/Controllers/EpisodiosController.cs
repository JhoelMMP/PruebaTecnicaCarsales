using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.UseCases;

namespace RickAndMorty.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpisodiosController : ControllerBase
    {
        private readonly ObtenerEpisodiosUseCase _obtenerEpisodiosUseCase;

        public EpisodiosController (ObtenerEpisodiosUseCase obtenerEpisodiosUseCase)
        {
            _obtenerEpisodiosUseCase = obtenerEpisodiosUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetEpisodios(int? pagina = null)
        {
            var episodios = await _obtenerEpisodiosUseCase.BuscarEpisodios(pagina);
            return Ok(episodios);
        }
    }
}
