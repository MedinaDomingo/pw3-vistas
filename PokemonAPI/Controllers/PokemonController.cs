using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonData.Entidades;
using PokemonServicios;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private IPokemonServicio _pokemonServicio;
        public PokemonController(IPokemonServicio pokemonServicer)
        {
            _pokemonServicio = pokemonServicer;
        }

        [HttpGet]
        public List<Pokemon> Get()
        {
            return _pokemonServicio.ObtenerTodos();
        }
        [HttpPost]
        public void Post([FromBody] Pokemon pokemon)
        {
            _pokemonServicio.Agregar(pokemon);
        }

    }
}
