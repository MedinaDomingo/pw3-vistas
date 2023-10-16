using Microsoft.AspNetCore.SignalR;

namespace PokemonSignalR.Hubs
{
    public class PokemonSelectorHub: Hub
    {
        private static int usuariosSeleccionados = 0;
        public async Task EnviaSeleccion(string pokemonNombre)
        {
            await Clients.All.SendAsync("RecibeSeleccion", pokemonNombre);
            usuariosSeleccionados++;
            if (usuariosSeleccionados == 2)
            {
                await Clients.All.SendAsync("RedirigeAPelea");
                usuariosSeleccionados = 0;
            }
        }
    }
}
