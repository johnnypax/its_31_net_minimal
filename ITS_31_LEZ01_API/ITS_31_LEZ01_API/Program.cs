using ITS_31_LEZ01_API.Classi;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

var garage = new List<Automobile>
{
    new Automobile { Id = 1, Targa = "AB123CD", Marca = "Fiat", Modello = "Panda", Prezzo = 9500.00m },
    new Automobile { Id = 2, Targa = "EF456GH", Marca = "Volkswagen", Modello = "Golf", Prezzo = 18900.00m },
    new Automobile { Id = 3, Targa = "IJ789KL", Marca = "Tesla", Modello = "Model 3", Prezzo = 39900.00m },
    new Automobile { Id = 4, Targa = "MN012OP", Marca = "BMW", Modello = "Serie 1", Prezzo = 24500.00m },
    new Automobile { Id = 5, Targa = "QR345ST", Marca = "Toyota", Modello = "Yaris", Prezzo = 17200.00m },
    new Automobile { Id = 6, Targa = "UV678WX", Marca = "Renault", Modello = "Clio", Prezzo = 15800.00m },
    new Automobile { Id = 7, Targa = "YZ901AB", Marca = "Audi", Modello = "A3", Prezzo = 28900.00m },
    new Automobile { Id = 8, Targa = "CD234EF", Marca = "Peugeot", Modello = "208", Prezzo = 16500.00m },
    new Automobile { Id = 9, Targa = "GH567IJ", Marca = "Hyundai", Modello = "i20", Prezzo = 14900.00m },
    new Automobile { Id = 10, Targa = "KL890MN", Marca = "Mercedes", Modello = "Classe A", Prezzo = 31500.00m }
};

// GET - /api/garage
app.MapGet("/api/garage", () =>
{
    var garageDTO = garage.Select(a => new
    {
        Mar = a.Marca,
        Mod = a.Modello,
        Tar = a.Targa,
        Pre = a.Prezzo
    });

    return Results.Ok(garageDTO);
});

// https://localhost:2563/api/garage/AB1234, tar = "AB1234"
app.MapGet("/api/garage/{tar}", (string tar) =>
{
    Automobile? autoTrovata = garage.FirstOrDefault(a => a.Targa == tar);

    if(autoTrovata == null)
        return Results.NotFound();

    var autoDTO = new
    {
        Mar = autoTrovata.Marca,
        Mod = autoTrovata.Modello,
        Tar = autoTrovata.Targa,
        Pre = autoTrovata.Prezzo
    };
    
    return Results.Ok(autoDTO);
});

// POST - /api/garage
app.MapPost("/api/garage", (Automobile auto) =>
{
    if (string.IsNullOrWhiteSpace(auto.Marca) || string.IsNullOrWhiteSpace(auto.Modello))
        return Results.BadRequest();


    auto.Id = garage.Count + 1;
    garage.Add(auto);

    return Results.Created("/api/garage/" + auto.Targa, null);
});

app.Run();
