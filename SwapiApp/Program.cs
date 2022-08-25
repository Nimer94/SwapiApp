using Microsoft.EntityFrameworkCore;
using SwapiApp.Data;
using SwapiApp.GraphQL;
using SwapiApp.Repository;
using SwapiApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Prepare the URI of the external API service (i.e., swapi.dev) from the config
IConfiguration configuration = builder.Configuration;
Uri uri = new(configuration.GetValue<string>("ClientUrl"));

// Instantiate the in-memory DB
builder.Services.AddPooledDbContextFactory<DataContext>(opt => opt.UseInMemoryDatabase(databaseName: "People"));
builder.Services.AddScoped<IClientRepository, ClientRepository>();

// Register the external API service under the name "SWAPI"
builder.Services.AddHttpClient<IClientService, ClientService>("SWAPI", client =>
{
    client.BaseAddress = uri;
});

// Register the GraphQL on the external API serivce
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();


var app = builder.Build();

// Initialize the GraphQL service
app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.Run();
