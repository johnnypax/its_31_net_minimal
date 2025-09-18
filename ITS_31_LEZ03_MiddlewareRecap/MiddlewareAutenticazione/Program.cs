using lez02_MiddlewareAutenticazione.Classi;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    if(context.Request.Path == "/login")
        await next.Invoke();
    else
    {
        if (context.Request.Headers.TryGetValue("Access", out var valoreToken))
        {
            if (valoreToken == "AB12345")
            {
                await next.Invoke();
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Accesso negato: token non valido.");
            }
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Accesso negato: token non presente.");
        }
    }
});

app.MapPost("/login", (Credenziali cred) =>
{
    if (string.IsNullOrWhiteSpace(cred.Password) || string.IsNullOrWhiteSpace(cred.Username))
        return Results.BadRequest();

    if (cred.Username == "Ciccio" && cred.Password == "Pasticcio")
        return Results.Ok(new { token = "AB12345" });

    return Results.BadRequest();
});

app.MapGet("/profilo", () =>
{
    return "info sensibili utente";
});

app.Run();