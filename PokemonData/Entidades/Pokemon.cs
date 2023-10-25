using System;
using System.Collections.Generic;

namespace PokemonData.Entidades;

public partial class Pokemon
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Vida { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<Ataque> Ataques { get; set; } = new List<Ataque>();
}
