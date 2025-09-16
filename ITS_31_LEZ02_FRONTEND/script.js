function stampa(){
    fetch("https://localhost:7293/api/menu")
        .then(response => {
            return response.json();
        })
        .then(dati => {

            for(let [indice, pizza] of dati.entries()){
                document.getElementById("corpo-tabella").innerHTML += `
                    <tr>
                        <td>${pizza.nome}</td>
                        <td>${pizza.isVegana}</td>
                        <td>${pizza.prezzo}</td>
                    </tr>
                `
            }

        })
}

stampa();