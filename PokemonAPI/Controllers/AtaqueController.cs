using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonData.Entidades;
using PokemonServicios;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtaqueController : ControllerBase
    {
        private IAtaqueServivio _ataqueServicio;
        public AtaqueController(IAtaqueServivio ataqueServicio)
        {
            _ataqueServicio = ataqueServicio;
        }

        [HttpGet]
        public List<Ataque> Get()
        {
            return _ataqueServicio.ObtenerAtaques();
        }
        [HttpGet("pokemon/{idPokemon}")]
        public List<Ataque> Get(int idPokemon)
        {
            return _ataqueServicio.ObtenerAtaquesPorIdDePokemon(idPokemon);
        }
        [HttpGet("{idAtaque}")]
        public Ataque GetAtaqueId(int idAtaque)
        {
            return _ataqueServicio.BuscarAtaquePorId(idAtaque);
        }
        [HttpPost]
        public void Post([FromBody]Ataque ataque) 
        {
            _ataqueServicio.AgregarAtaque(ataque);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ataque ataque)
        {
            Ataque ataqueModificar = _ataqueServicio.BuscarAtaquePorId(id);
            if (ataqueModificar == null)
            {
                return BadRequest();
            }
            ataqueModificar.Nombre = ataque.Nombre;
            _ataqueServicio.ModificarAtaque(ataqueModificar);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Ataque ataque = _ataqueServicio.BuscarAtaquePorId(id);
            if(ataque == null)
            {
                return BadRequest();
            }

            _ataqueServicio.EliminarAtaque(ataque);
            return Ok();
        }

    }
}
