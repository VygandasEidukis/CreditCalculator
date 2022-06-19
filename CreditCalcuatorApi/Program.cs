using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
IConfigurationRoot? configuration = builder.Configuration
    .AddJsonFile("appsettings.json")
    .Build();

IConfiguration configuratio1n = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
