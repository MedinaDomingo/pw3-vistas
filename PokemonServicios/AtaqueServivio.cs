using PokemonData.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PokemonServicios
{
    public interface IAtaqueServivio
    {
        List<Ataque> ObtenerAtaquesPorIdDePokemon(int id);
        void ModificarAtaque(Ataque ataque);
        Ataque BuscarAtaquePorId(int id);
        List<Ataque> ObtenerAtaques();
        void EliminarAtaque(Ataque ataque);
        void AgregarAtaque(Ataque ataque);
    }
    public class AtaqueServivio: IAtaqueServivio
    {
        private PokemonJuegoContext _contexto;
        public AtaqueServivio(PokemonJuegoContext contexto)
        {
            _contexto = contexto;
        }

        public List<Ataque> ObtenerAtaquesPorIdDePokemon(int id)//Estado Unchanged
        {
            var ataques = from a in _contexto.Ataques where a.IdPokemon == id select a;
            return ataques.ToList();
        }
        public void ModificarAtaque(Ataque ataque)//Estado Modified
        {
            if(_contexto.Ataques.Find(ataque.Id)==null){
                throw new Exception("No existe el ataque");
            }
            _contexto.Update(ataque);

            _contexto.SaveChanges();
        }

        public Ataque BuscarAtaquePorId(int id)//Estado Unchanged
        {

            return _contexto.Ataques.SingleOrDefault(s => s.Id == id); ;
        }

        public List<Ataque> ObtenerAtaques()//Estado Unchanged
        {
            var ataques = (from a in _contexto.Ataques select a);
            var ataques2 = _contexto.Ataques.Select(a => a);
            return ataques2.ToList();
        }

        public void EliminarAtaque(Ataque ataque)
        {
            _contexto.Remove(ataque);//Estado DELETED
            _contexto.SaveChanges();
        }

        public void AgregarAtaque(Ataque ataque)// Estado ADDED
        {
            _contexto.Add(ataque);
            _contexto.SaveChanges();
        }
    }
}
