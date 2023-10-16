using Microsoft.AspNetCore.Mvc;

namespace PokemonSignalR.Controllers
{
    public class PokemonSelectorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
