using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonData.Entidades;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtaqueController : ControllerBase
    {
        PokemonJuegoContext _contexto = new PokemonJuegoContext();
        [HttpGet]
        public Ataque Get()
        {
            return _contexto.Ataques.Include(a => a.IdPokemonNavigation)
                                .FirstOrDefault(a => a.Id == 1);
        }
        [HttpPost]
        public void Post([FromBody]Ataque ataque) 
        {
            _contexto.Add(ataque);
            _contexto.SaveChanges();
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Ataque ataque)
        {
            ataque.Id = id;
            _contexto.Update(ataque);
            _contexto.SaveChanges();
        }
    }
}
