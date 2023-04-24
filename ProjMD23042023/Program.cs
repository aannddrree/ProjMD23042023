using Microsoft.Extensions.Options;
using ProjMB23042023.Services;
using Microsoft.Extensions.Configuration;
using ProjMB23042023.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.Configure<ProjMongoDotnetDatabaseSettings>(builder.Configuration.GetSection("ProjMongoDotnetDatabaseSettings"));

builder.Services.AddSingleton<IProjMongoDotnetDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ProjMongoDotnetDatabaseSettings>>().Value);

builder.Services.AddSingleton<ClientService>();
builder.Services.AddSingleton<AddressService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
