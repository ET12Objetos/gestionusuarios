using Dominio;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    //se agrega la opcion de EnableTryItOutDefault
    //ya no se debe hacer click en el boton azul "Try It Out"
    app.UseSwaggerUI(options => options.EnableTryItOutByDefault());
}

app.UseHttpsRedirection();

//creo una lista de objetos de roles para poder probar los 
//endpoints asociados a la entidad "Rol"
List<Rol> roles = [
    new Rol { IdRol = 1, Nombre = "Administrador" },
    new Rol { IdRol = 2, Nombre = "Soporte" }
    ];

//endpoint que redirecciona a Swagger directamente cuando 
//se hace click en la URL http://localhost:5000 (aparece en 
//la consola al ejecutar el comando "dotnet run")
app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapGet("/ejemplo", () =>
{
    return Results.Ok("Hola mundo");
});

//endpoind de lectura de objetos de la entidad rol
//Nombre del recurso es: /rol
//Datos de entrada: no posee
//Datos de salida: es un 200 Ok (status code) y la lista de roles
app.MapGet("/rol", () =>
{
    return Results.Ok(roles);
});

//endpoind de escritura de objetos de la entidad rol
//Nombre del recurso es: /rol
//Datos de entrada: un objeto Rol (C#/JSON)
//Datos de salida: es un 200 Ok (status code) y la lista de roles con el nuevo
//rol creado
app.MapPost("/rol", (Rol rol) =>
{
    roles.Add(rol);
    return Results.Ok(roles);
});

app.Run();