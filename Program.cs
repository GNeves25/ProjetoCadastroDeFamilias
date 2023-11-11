using Microsoft.EntityFrameworkCore;
using ProjetoCadastroDeFamilias.Data;
using ProjetoCadastroDeFamilias.Repositorios;
using ProjetoCadastroDeFamilias.Repositorios.Interfaces;
using ProjetoCadastroDeFamilias.Service;
using ProjetoCadastroDeFamilias.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
        //.AddDbContext<SistemaDeCadastroDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
        .AddDbContext<SistemaDeCadastroDBContext>(options => options.UseOracle(builder.Configuration.GetConnectionString("DataBaseOracle")));
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IFamiliaRepositorio, FamiliaRepositorio>();
builder.Services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
