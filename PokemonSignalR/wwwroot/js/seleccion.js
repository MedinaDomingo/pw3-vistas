var connection = new signalR.HubConnectionBuilder().withUrl("/pokemonSelectorHub").build();

connection.start().then(function () {
    console.log("Conexión establecida");
}).catch(function (err) {
    return console.error(err.toString());
});


function seleccionarPokemon(pokemonId, elemento) {
    connection.invoke('EnviaSeleccion', pokemonId).catch(function (err) {

        return console.error(err.toString());
    });
    let pokemones = document.querySelectorAll('.pokemon-card');
    pokemones.forEach(function (elemento) {
        elemento.onclick = null;
    });

}


connection.on("RecibeSeleccion", function (pokemonId) {
    console.log("Pokemon seleccionado: " + pokemonId);
    let element = document.getElementById(pokemonId)
    if (element) {
        element.classList.add('bg-opacity-100');
    }
});

connection.on("RedirigeAPelea", function (yo, contrario) {
    window.location.href = 'batalla?yo=' + yo + '&contrario=' + contrario;
});