var builder = WebApplication.CreateBuilder(args);

// Register the GraphQL on the external API serivce
builder.Services
    .AddGraphQLServer();

var app = builder.Build();

// Initialize the GraphQL service
app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

app.Run();
