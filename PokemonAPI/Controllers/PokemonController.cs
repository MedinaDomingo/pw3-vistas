using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonData.Entidades;
using PokemonServicios;
using System.Text.Json.Serialization;
using System.Text.Json;

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
        public IActionResult Get()
        {
            var objeto = _pokemonServicio.ObtenerTodos();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var json = JsonSerializer.Serialize(objeto, options);
            return Ok(json);
        }
        [HttpPost]
        public void Post([FromBody] Pokemon pokemon)
        {
            _pokemonServicio.Agregar(pokemon);
        }

    }
}
