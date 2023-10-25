using System;
using System.Collections.Generic;

namespace PokemonData.Entidades;

public partial class Ataque
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdPokemon { get; set; }

    public virtual Pokemon? IdPokemonNavigation { get; set; }
}
