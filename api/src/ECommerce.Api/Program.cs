using Microsoft.EntityFrameworkCore;
using ECommerce.Data;

// ✅ REQUIRED for Azure SQL + AAD in Linux containers (Codespaces)
AppContext.SetSwitch("System.Globalization.Invariant", false);

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5095");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Sql")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory API v1");
        options.RoutePrefix = string.Empty; // Swagger at /
    });
}
app.MapControllers();

app.Run();