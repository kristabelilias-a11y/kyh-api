using kyh_api.Models;
using kyh_api.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/encrypt", (Kryptering request) =>
{
    var encrypted = CaesarChiffer.Encrypt(request.Text, request.Shift);
    return Results.Ok(new { original = request.Text, shift = request.Shift, encrypted });
});

app.MapPost("/decrypt", (Kryptering request) =>
{
    var decrypted = CaesarChiffer.Decrypt(request.Text, request.Shift);
    return Results.Ok(new { original = request.Text, shift = request.Shift, decrypted });
});

app.MapGet("/", () => "kyh-api is running!");

app.Run(); 