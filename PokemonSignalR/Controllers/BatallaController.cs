using Microsoft.AspNetCore.Mvc;

namespace PokemonSignalR.Controllers
{
    public class BatallaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
