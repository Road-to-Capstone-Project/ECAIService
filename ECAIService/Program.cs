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
using ECAIService.Services.Scripts;
using System.Media;
using Castle.DynamicProxy;
using System.Diagnostics;
using Serilog;
using Serilog.Extensions.Logging;

var waitTimeMs = 5000;

Console.WriteLine($"Blocking for {waitTimeMs}ms");
//await Task.Delay( waitTimeMs );

args = args.Select(it => it.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)).SelectMany().ToArray();

var argsSet = args.ToHashSet();

Console.WriteLine(argsSet.JoinToString(",\n"));

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .CreateLogger();

var loggingFactory = new SerilogLoggerFactory();
var logger = loggingFactory.CreateLogger<Program>();

builder.Host.UseSerilog();

// Add services to the container.

var connectionString = "Host=localhost;Port=5432;Database=c.v.o.s;Username=postgres;Password=admin;Include Error Detail=true";

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<CVOSContext>(options =>
    options.UseNpgsql(connectionString)
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging()
    .LogTo(i => logger.Log(LogLevel.Debug, i))
    );

builder.Services.AddSingleton<MLContext>();
builder.Services.AddSingleton<IEncodingService, EncodingService>();

SqlMapper.AddTypeHandler(new VectorTypeHandler());

var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString).Apply(it =>
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

builder.Services.AddScoped<NpgsqlConnectionDisposables>(i =>
    i.GetRequiredService<NpgsqlDataSourceBuilder>().Build().Let(it => new NpgsqlConnectionDisposables(it, it.CreateConnection()))
);

"".Let(string.Join, ';');

builder.Services.AddSingleton(new Device((cuda.is_available())? DeviceType.CUDA : DeviceType.CPU));

builder.Services.AddSingleton<Random>();

var scriptServiceDict = new Dictionary<string, Type>();

builder.Services.AddSingleton(new ProxyGenerator());

var proxyOptions = new ProxyGenerationOptions();
proxyOptions.Hook = new AllMethodsHook();


void AddScriptService<T>()
{
    scriptServiceDict.Add(typeof(T).Name, typeof(T));
}

AddScriptService<ImportGooglePlayApps>();
AddScriptService<DataCleaner>();
AddScriptService<GNNService>();
AddScriptService<SessionGenerator>();
AddScriptService<TokenDictionaryService>();
AddScriptService<RemoveGooglePlayApps>();

foreach (var arg in args)
{
    if (scriptServiceDict.TryGetValue(arg, out Type? value))
    {
        builder.Services.AddTransient(value);
    }
}

random.manual_seed(42);
cuda.manual_seed(42);

cuda.manual_seed_all(42);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var stopWatch = new Stopwatch();
    //Directory.CreateDirectory("Resources/Logs");
    //using var fileStream = File.AppendText("Resources/Logs/Startup.txt");
    foreach (var arg in args)
    {
        if (scriptServiceDict.TryGetValue(arg, out Type? value))
        {
            stopWatch.Restart();

            scope.ServiceProvider.GetRequiredService(value);

            stopWatch.Stop();
            logger.Log(LogLevel.Debug, "Script {Name} took {ElapsedMilliseconds}ms", value.Name, stopWatch.ElapsedMilliseconds);
        }
    }
}

if (OperatingSystem.IsWindows())
{
    //SystemSounds.Asterisk.Play();
    SystemSounds.Beep.Play();
    //SystemSounds.Exclamation.Play();
    //SystemSounds.Hand.Play();
    //SystemSounds.Question.Play();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (argsSet.Contains("ScriptsOnly").Not())
{
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}