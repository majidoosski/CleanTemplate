using CleanTemplate.Persistence;
using CleanTemplate.WebApi;

var builder = WebApplication.CreateBuilder(args);

//maualy startup
var startUp = new StartUp(builder.Configuration);

startUp.ConfigureServices(builder.Services);

// Add services to the container.

var app = builder.Build();

startUp.Configure(app);

// Configure the HTTP request pipeline.

//Initial persitence layer

await app.Services.InitPersistence(builder.Configuration);

app.Run();

