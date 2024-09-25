#region Using
using System.IO.Pipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Domnio.ModelViews;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;
#endregion

#region Builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();
builder.Services.AddScoped<IVeiculoServico, VeiculoServico>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContexto>(options =>{
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect( builder.Configuration.GetConnectionString("mysql"))
    );
});

var app = builder.Build();
#endregion

#region Home
app.MapGet("/", () => Results.Json(new Home()));
#endregion

#region Administradores
app.MapPost("/administradores/login",([FromBody]LoginDTO loginDTO, IAdministradorServico administradorServico) => {
    if(administradorServico.Login(loginDTO) != null)
          return Results.Ok("Login com sucesso");
    else 
          return Results.Unauthorized();
         
}).WithTags("Administrador");
#endregion

#region Veiculos
app.MapPost("/veiculos",([FromBody]VeiculoDTO veiculoDTO, IVeiculoServico veiculoServico) => {

    var veiculo = new Veiculo{
    Nome = veiculoDTO.Nome,
    Marca= veiculoDTO.Marca,
    Ano = veiculoDTO.Ano
    };
    veiculoServico.Incluir(veiculo);
    return Results.Created($"/veiculo/{veiculo.Id}", veiculo);
}).WithTags("Veiculo");

app.MapGet("/veiculos",([FromQuery]int? pagina, IVeiculoServico veiculoServico) => {
var veiculo = veiculoServico.Todos(pagina);
    
    return Results.Ok(veiculo);
}).WithTags("Veiculo");

app.MapGet("/veiculos/{id}",([FromRoute]int id, IVeiculoServico veiculoServico) => {
var veiculo = veiculoServico.BuscaPorId(id);

if(veiculo == null) return Results.NotFound();
    
    return Results.Ok(veiculo);
}).WithTags("Veiculo");

app.MapPut("/veiculos/{id}",([FromRoute]int id, VeiculoDTO veiculoDTO,IVeiculoServico veiculoServico) => {

var veiculo = veiculoServico.BuscaPorId(id);
if(veiculo == null) return Results.NotFound();
    veiculo.Nome = veiculoDTO.Nome;
    veiculo.Marca= veiculoDTO.Marca;
    veiculo.Ano = veiculoDTO.Ano;

    veiculoServico.Atualizar(veiculo);
   
    return Results.Ok(veiculo);
}).WithTags("Veiculo");

app.MapDelete("/veiculos/{id}",([FromRoute]int id, IVeiculoServico veiculoServico) => {

var veiculo = veiculoServico.BuscaPorId(id);
if(veiculo == null) return Results.NotFound();
   

    veiculoServico.Apagar(veiculo);
    return Results.NoContent();
    
}).WithTags("Veiculo");
#endregion

#region App
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
#endregion