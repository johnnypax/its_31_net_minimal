function salva(){

    let nome = document.getElementById("input-nome").value;
    let vegana = document.getElementById("input-vegana").value;
    let prezzo = document.getElementById("input-prezzo").value;

    let corpo = {
        nome,
        isvegana: vegana == "true" ? true : false,
        prezzo
    }

    fetch("https://localhost:7293/api/menu", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(corpo)
    })
    .then(response => {
        alert("OK");
        window.location.href = "index.html"
    })
    .catch(errore => {
        console.log(errore)
    })

}