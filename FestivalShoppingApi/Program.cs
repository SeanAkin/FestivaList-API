using FestivalShoppingApi.Data;
using FestivalShoppingApi.Domain.Contracts;
using FestivalShoppingApi.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHealthChecks();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FestivalShoppingContext>(opt 
    => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IShoppingListService, ShoppingListService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddRateLimiter(opt => RateLimitingOptionsExtensions.ConfigureRateLimitingOptions(opt));
}

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FestivalShoppingContext>();
    context.Database.Migrate();
}

app.MapHealthChecks("/health");

app.UsePathBase("/festival-shopping-api");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

if (!app.Environment.IsDevelopment())
{
    app.UseRateLimiter();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }