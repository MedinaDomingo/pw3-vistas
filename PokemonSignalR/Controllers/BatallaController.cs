using Microsoft.AspNetCore.Mvc;
using PokemonData.Entidades;
using PokemonServicios;

namespace PokemonSignalR.Controllers
{
    public class BatallaController : Controller
    {
        private IPokemonServicio pokemonServicios;
        public BatallaController(IPokemonServicio pokemonServicios)
        {
            this.pokemonServicios = pokemonServicios;
        }
        public IActionResult Index()
        {
            int yo;
            int.TryParse(HttpContext.Request.Query["yo"], out yo);

            int contrario;
            int.TryParse(HttpContext.Request.Query["contrario"],out contrario);

            Pokemon pokemonYo = pokemonServicios.ObtenerPorId(yo);
            Pokemon pokemonContrario = pokemonServicios.ObtenerPorId(contrario);

            List<Pokemon> pokemones = new List<Pokemon>();

            pokemones.Add(pokemonYo);
            pokemones.Add(pokemonContrario);

            return View(pokemones);
        }

    }
}
