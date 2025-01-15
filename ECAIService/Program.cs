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
using System.Text.Encodings.Web;
using System.Web;
using Newtonsoft.Json;

var waitTimeMs = 5000;

Console.WriteLine($"Blocking for {waitTimeMs}ms");
//await Task.Delay( waitTimeMs );

args = args.Select(it => it.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)).SelectMany().ToArray();

var argsSet = args.ToHashSet();

Console.WriteLine(argsSet.JoinToString(",\n"));

//Console.WriteLine(HttpUtility.UrlEncode("/"));

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
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
    .LogTo(i => logger.Log(LogLevel.Trace, i), LogLevel.Trace)
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
    where T : class, IAsyncScript
{
    //scriptServiceDict.Add(typeof(T).Name, typeof(T));
    builder.Services.AddKeyedTransient<IAsyncScript, T>(typeof(T).Name);
    builder.Services.AddTransient<IAsyncScript, T>();
}

AddScriptService<ImportGooglePlayApps>();
AddScriptService<DataCleaner>();
AddScriptService<GNNService>();
builder.Services.AddTransient<GNNService>();
builder.Services.AddKeyedSingleton<ICollection<string>>(nameof(GNNService), ["-r"]);
AddScriptService<SessionGenerator>();
AddScriptService<TokenDictionaryService>();
AddScriptService<RemoveGooglePlayApps>();

random.manual_seed(42);
cuda.manual_seed(42);

cuda.manual_seed_all(42);

var app = builder.Build();

foreach(var service in builder.Services)
{
    //logger.LogInformation(service.ToString());
}

using (var scope_ = app.Services.CreateScope())
{
    var stopWatch = new Stopwatch();
    //Directory.CreateDirectory("Resources/Logs");
    //using var fileStream = File.AppendText("Resources/Logs/Startup.txt");
    foreach (var arg in args)
    {
        var script = app.Services.GetKeyedService<IAsyncScript>(arg);
        if (script is not null)
        {
            await script.ExecuteAsync();
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