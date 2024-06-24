using Microsoft.OpenApi.Models;
using Zanzarah_fairy_book;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo()
{
    Title = "Zanzarah_Book",
    Description = "Zanzarah Book example",
    Version = "1.0"
}));
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });

app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.MapControllers();

app.Run();