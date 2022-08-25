using Microsoft.EntityFrameworkCore;
using SwapiApp.Data;
using SwapiApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Instantiate the in-memory DB
builder.Services.AddPooledDbContextFactory<DataContext>(opt => opt.UseInMemoryDatabase(databaseName: "People"));
builder.Services.AddScoped<IClientRepository, ClientRepository>();

// Register the GraphQL on the external API serivce
builder.Services
    .AddGraphQLServer();

var app = builder.Build();

// Initialize the GraphQL service
app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.Run();
