using PokemonData.Entidades;

namespace PokemonServicios
{
    public interface IPokemonServicio
    {
        void Agregar(Pokemon pokemon);
        List<Pokemon> ObtenerTodos();
        Pokemon ObtenerPorId(int id);
        void Actualizar(Pokemon pokemon);
        void Eliminar(int id);
    }
    public class PokemonServicio : IPokemonServicio
    {
        private PokemonJuegoContext _contexto;
        public PokemonServicio(PokemonJuegoContext _contexto)
        {
            this._contexto = _contexto;
        }
        public void Actualizar(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public void Agregar(Pokemon pokemon)
        {
            _contexto.Pokemons.Add(pokemon);
            _contexto.SaveChanges();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Pokemon ObtenerPorId(int id)
        {
            return _contexto.Pokemons.Find(id);
        }

        public List<Pokemon> ObtenerTodos()
        {
            return _contexto.Pokemons.ToList();
        }
    }
}