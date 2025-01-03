using Dapper;

using ECAIService;
using ECAIService.Data;

using Microsoft.EntityFrameworkCore;
using static ECAIService.Consts;
using Npgsql;
using Microsoft.ML;
using ECAIService.Services.Abstractions;
using ECAIService.Services;
using Pgvector.Dapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = "Host=localhost;Port=5432;Database=c.v.o.s;Username=postgres;Password=admin";

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<CVOSContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddSingleton<MLContext>();
builder.Services.AddSingleton<IEncodingService, EncodingService>();

SqlMapper.AddTypeHandler(new VectorTypeHandler());

var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString).Apply(async it =>
{
    it.UseVector();
});

using var dataSource = dataSourceBuilder.Build();
using var connection = await dataSource.OpenConnectionAsync();

connection.Execute("CREATE EXTENSION IF NOT EXISTS vector");
connection.ReloadTypes();
connection.Execute($"CREATE TABLE IF NOT EXISTS {ContentBasedVectorTable} (variant_id character varying(255), embeddings vector(1)" +
    $",CONSTRAINT {ContentBasedVectorName}_pkey PRIMARY KEY (variant_id)" +
    $",CONSTRAINT {ContentBasedVectorName}_fkey FOREIGN KEY (variant_id) REFERENCES public.product_variant (id)" +
    $")");

builder.Services.AddSingleton<NpgsqlDataSourceBuilder>
(
    dataSourceBuilder
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
