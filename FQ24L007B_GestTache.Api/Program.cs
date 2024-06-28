using FQ24L007B_GestTache.Api.Models.Repositories;
using FQ24L007B_GestTache.Api.Models.Services;
using Microsoft.Data.SqlClient;
using System.Data.Common;

string corsPolicyName = "_";

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(o => o.AddPolicy(corsPolicyName, b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DbConnection>(sp => new SqlConnection(configuration.GetConnectionString("default")));
builder.Services.AddScoped<ITacheRepository, TacheService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(corsPolicyName);

app.MapControllers();

app.Run();
