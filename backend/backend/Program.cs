using System.Data;
using backend.Adapters;
using backend.Core;
using backend.Services;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Register the database connection
builder.Services.AddSingleton<IDbConnection>(sp =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});

// Register repositories
builder.Services.AddSingleton<ICatRepository, PostgresCatRepository>();
builder.Services.AddSingleton<IVotingRepository, VotingRepository>();

// Register services
builder.Services.AddSingleton<ICatService, CatService>();
builder.Services.AddSingleton<IVotingService, VotingService>();

// Add controller services
builder.Services.AddControllers();

var app = builder.Build();

// Initialize the database with cat data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var jsonCatRepository = new JsonCatRepository("https://data.latelier.co/cats.json");
    var postgresCatRepository = services.GetRequiredService<ICatRepository>();

    var cats = await jsonCatRepository.GetAllCats();
    foreach (var cat in cats)
    {
        await postgresCatRepository.SaveCat(cat);
    }
}

// Configure controller routing
app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();