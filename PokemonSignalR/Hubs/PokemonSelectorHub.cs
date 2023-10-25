using Microsoft.AspNetCore.SignalR;

namespace PokemonSignalR.Hubs
{
    public class PokemonSelectorHub: Hub
    {
        private static List<string> pokemonesSeleccionados = new List<string>();
        private static int usuariosSeleccionados = 0;
        
        public async Task EnviaSeleccion(string pokemonId)
        {
            pokemonesSeleccionados.Add(pokemonId);
            await Clients.All.SendAsync("RecibeSeleccion", pokemonId);
            usuariosSeleccionados++;
            if (usuariosSeleccionados == 2)
            {
                string yo = pokemonesSeleccionados[0];
                string contrario = pokemonesSeleccionados[1];

                await Clients.All.SendAsync("RedirigeAPelea", yo, contrario);
                usuariosSeleccionados = 0;
                pokemonesSeleccionados.Clear();
            }
        }
    }
}
