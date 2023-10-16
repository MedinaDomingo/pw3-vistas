var connection = new signalR.HubConnectionBuilder().withUrl("/pokemonSelectorHub").build();

connection.start().then(function () {
    console.log("Conexión establecida");
}).catch(function (err) {
    return console.error(err.toString());
});


function seleccionarPokemon(pokemonNombre, elemento) {
    connection.invoke('EnviaSeleccion', pokemonNombre).catch(function (err) {

        return console.error(err.toString());
    });
    let pokemones = document.querySelectorAll('.pokemon-card');
    pokemones.forEach(function (elemento) {
        elemento.onclick = null;
    });

}


connection.on("RecibeSeleccion", function (pokemonNombre) {
    console.log("Pokemon seleccionado: " + pokemonNombre);
    let element = document.getElementById(pokemonNombre)
    if (element) {
        element.classList.add('bg-opacity-100');
    }
});

connection.on("RedirigeAPelea", function () {
    window.location.href = 'batalla';

});