

using JasperFx.CodeGeneration.Frames;
using Marten.Linq.Includes;
using Microsoft.Extensions.Configuration;
using Weasel.Core.Migrations;

var builder = WebApplication.CreateBuilder(args);

//Add service to the container.
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviours<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    var dbHost = Environment.GetEnvironmentVariable("HOST");
    var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB");
    var userName = Environment.GetEnvironmentVariable("POSTGRES_USER");
    var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
    var port = Environment.GetEnvironmentVariable("PORT");

    var connectionString = string.Empty;
    if (string.IsNullOrEmpty(dbHost) ||
        string.IsNullOrEmpty(dbName) ||
        string.IsNullOrEmpty(userName) ||
        string.IsNullOrEmpty(port) ||
        string.IsNullOrEmpty(password)){
        connectionString = builder.Configuration.GetConnectionString("Database");
        Console.WriteLine("Ankit" + connectionString);
    } else {
        connectionString = $"Server = {dbHost}; Port = {port}; Database = {dbName}; User Id = {userName}; password = {password}; Include Error Detail = true";
        //connectionString = $"Host={dbHost};Database={dbName};Username={userName};Password={password}";
        Console.WriteLine("Ankit" + connectionString);
    }
    opts.Connection(connectionString!);
}).UseLightweightSessions();

/*if(builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();*/

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks();

var app = builder.Build();

//Config the HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health");

app.Run();
