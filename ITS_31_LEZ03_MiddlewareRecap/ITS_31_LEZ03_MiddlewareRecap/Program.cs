using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

#region Middleware standard Content Type
//app.Use(async (context, next) =>
//{
//    var logger = app.Logger;
//    logger.LogWarning("Invocato Middleware");

//    string? ct = context.Request.ContentType;
//    logger.LogInformation(ct);

//    await next.Invoke();
//});
#endregion

#region Recupero informazioni Header
//app.Use(async (context, next) => {

//    var logger = app.Logger;


//    if (context.Request.Headers.TryGetValue("Header-Nome", out var valoreNome))
//    {
//        logger.LogInformation(valoreNome);
//    }

//    if (context.Request.Headers.TryGetValue("Header-Cognome", out var valoreCognome))
//    {
//        logger.LogInformation(valoreCognome);
//    }

//    await next.Invoke();
//});
#endregion

app.Use(async (context, next) => {

    var logger = app.Logger;

    if (
        context.Request.Headers.TryGetValue("Header-Username", out var valUser) && context.Request.Headers.TryGetValue("Header-Password", out var valPassword))
    {
        //logger.LogWarning($"Username: {valUser} Password: {valPassword}");
        if (valUser == "Ciccio" && valPassword == "Pasticcio")
        {
            await next.Invoke();
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Accesso negato: credenziali non valide.");
        }
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        await context.Response.WriteAsync("Accesso negato: header di autorizzazione non presenti.");
    }
});

app.MapGet("/", () =>
{
    var logger = app.Logger;
    logger.LogInformation("Invocato Home");

    return "Ciao sono endpoint Home";
});


app.MapGet("/secondario", () =>
{
    var logger = app.Logger;
    logger.LogInformation("Invocato Secondario");

    return "Ciao sono endpoint Secondario";
});

app.UseHttpsRedirection();

app.Run();