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
using System.Text.Json;
using System.Text.Json.Serialization;
using ECAIService.Serializers;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ECAIService.Proxy;
using System.Text;

const int seed = 42;
//var waitTimeMs = 5000;

//Console.WriteLine($"Blocking for {waitTimeMs}ms");
//await Task.Delay( waitTimeMs );

args = args.Select(it => it.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)).SelectMany().ToArray();

var argsSet = args.ToHashSet();

Console.WriteLine(argsSet.JoinToString(",\n"));

//Console.WriteLine(HttpUtility.UrlEncode("/"));

var builder = WebApplication.CreateBuilder(args);


var commonLogConfig = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext();

var logOnlyConfig = new LoggerConfiguration()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext();

Log.Logger = commonLogConfig
    .CreateLogger();

var loggingFactory = new SerilogLoggerFactory();
var logOnlyFactory = new SerilogLoggerFactory(logOnlyConfig.CreateLogger());

var logger = loggingFactory.CreateLogger<Program>();

var logOnlyLogger = logOnlyFactory.CreateLogger<CVOSContext>();

var jsonOptions = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true,
    WriteIndented = true
};

builder.Host.UseSerilog();
builder.Services.AddSingleton(jsonOptions);
builder.Services.AddMvc().AddJsonOptions(i =>
{
    i.AllowInputFormatterExceptionMessages = true;
    var o = i.JsonSerializerOptions;
    o.AllowOutOfOrderMetadataProperties = true;
    o.AllowTrailingCommas = true;
    o.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
    o.ReadCommentHandling = JsonCommentHandling.Skip;
    o.NumberHandling = 
        JsonNumberHandling.AllowNamedFloatingPointLiterals |
        JsonNumberHandling.AllowReadingFromString;
    o.RespectNullableAnnotations = true;
    o.RespectRequiredConstructorParameters = true;

    o.Converters.Add(new OneOfJsonConverter());
});

// Add services to the container.

var connectionString = "Host=localhost;Port=5432;Database=c.v.o.s;Username=postgres;Password=admin;Include Error Detail=true";

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<CVOSContext>(options =>
    options.UseNpgsql(connectionString, i => i.UseVector())
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging()
    .UseSnakeCaseNamingConvention()
    .LogTo(i => logOnlyLogger.Log(LogLevel.Trace, i), LogLevel.Trace)
    );

builder.Services.AddSingleton<MLContext>();
builder.Services.AddSingleton<IEncodingService, EncodingService>();

SqlMapper.AddTypeHandler(new VectorTypeHandler());

var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString).Apply(it =>
{
    it.UseVector();
});
{
    using var dataSource = dataSourceBuilder.Build();
    using var connection = await dataSource.OpenConnectionAsync();

    connection.Execute("CREATE EXTENSION IF NOT EXISTS vector");
    connection.ReloadTypes();
    connection.Execute($"CREATE TABLE IF NOT EXISTS {ContentBasedVectorTable} (variant_id character varying(255), embeddings vector(1)" +
        $",CONSTRAINT {ContentBasedVectorName}_pkey PRIMARY KEY (variant_id)" +
        $",CONSTRAINT {ContentBasedVectorName}_fkey FOREIGN KEY (variant_id) REFERENCES public.product_variant (id)" +
        $")");
}

builder.Services.AddSingleton<NpgsqlDataSourceBuilder>
(
    dataSourceBuilder
);

builder.Services.AddScoped<NpgsqlConnectionDisposables>(i =>
    i.GetRequiredService<NpgsqlDataSourceBuilder>().Build().Let(it => new NpgsqlConnectionDisposables(it, it.CreateConnection()))
);

builder.Services.AddSingleton(new Device((cuda.is_available())? DeviceType.CUDA : DeviceType.CPU));
builder.Services.AddTransient<Random>(_ => new Random(42));

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
AddScriptService<SessionToCSV>();
AddScriptService<RNNScript>();
AddScriptService<ReviewsToCSV>();

builder.Services.AddTransient<RNNFactory.Arguments>();
builder.Services.AddTransient<RNNFactory>();
builder.Services.AddSingleton<MemoryManager>();
builder.Services.AddSingleton<RNNModelService>();

builder.Services.AddSingleton<ExternalTokenizer>();
builder.Services.AddSingleton<ExternalTransformer>();
builder.Services.AddSingleton<VariantFeaturesSelector>();

random.manual_seed(42);
cuda.manual_seed(42);

cuda.manual_seed_all(42);

// List all available physical devices
var devices = tf.config.list_physical_devices();
foreach (var device in devices)
{
    Console.WriteLine(device);
}

// Check for GPU explicitly
var gpus = tf.config.list_physical_devices("GPU");
if (gpus.Length > 0)
{
    Console.WriteLine("GPU detected:");
    foreach (var gpu in gpus)
        Console.WriteLine(gpu);
    try
    {
        foreach (var gpu in gpus)
        {
            tf.config.experimental.set_memory_growth(gpu, true);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error setting memory growth: {e.Message}");
    }
}
else
{
    Console.WriteLine("No GPU detected. Using CPU.");
}

var app = builder.Build();

//foreach(var service in builder.Services)
//{
//    logger.LogInformation(service.ToString());
//}

using (var scope = app.Services.CreateScope())
{
    var stopWatch = new Stopwatch();
    //Directory.CreateDirectory("Resources/Logs");
    //using var fileStream = File.AppendText("Resources/Logs/Startup.txt");
    foreach (var arg in args)
    {
        var script = scope.ServiceProvider.GetKeyedService<IAsyncScript>(arg);
        if (script is not null)
        {
            await script.ExecuteAsync();
        }
    }

    using var cVOSContext = scope.ServiceProvider.GetRequiredService<CVOSContext>();

    //if (File.Exists("Resources/Database.dgml").Not())
    //    File.WriteAllText("Resources/Database.dgml", cVOSContext.AsDgml(), Encoding.UTF8);

    //try
    //{
    //    var databaseCreator = (cVOSContext.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator);
    //    databaseCreator?.CreateTables();
    //}
    //catch (System.Data.SqlClient.SqlException)
    //{

    //}
    //catch (PostgresException)
    //{

    //}
}

//app.Services.GetRequiredService<RNNModelService>();

async Task soundRoutine(Action sound)
{
    sound();
    await Task.Delay(2000);
}

if (OperatingSystem.IsWindows())
{
    //await soundRoutine(() => SystemSounds.Asterisk.Play());
    //await soundRoutine(() => SystemSounds.Beep.Play());
    //await soundRoutine(() => SystemSounds.Exclamation.Play());
    //await soundRoutine(() => SystemSounds.Hand.Play());
    //await soundRoutine(() => SystemSounds.Question.Play());
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