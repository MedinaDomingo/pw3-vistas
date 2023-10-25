using Microsoft.AspNetCore.Mvc;
using PokemonData.Entidades;
using PokemonServicios;

namespace PokemonSignalR.Controllers
{
    public class PokemonSelectorController : Controller
    {
        private IPokemonServicio pokemonServicios;
        public PokemonSelectorController(IPokemonServicio pokemonServicios)
        {
            this.pokemonServicios = pokemonServicios;
        }
        public IActionResult Index()
        {
            List<Pokemon> pokemones = pokemonServicios.ObtenerTodos();
            return View(pokemones);
        }

    }
}
