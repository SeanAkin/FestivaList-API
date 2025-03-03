using System.Threading.RateLimiting;
using FestivalShoppingApi.Data;
using FestivalShoppingApi.Domain.Contracts;
using FestivalShoppingApi.Domain.Services;
using FestivalShoppingApi.Transformers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(o =>
{
    o.Conventions.Add(new RouteTokenTransformerConvention(new LowercaseRouteTransformer()));
});
builder.Services.AddHealthChecks();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FestivalShoppingContext>(opt 
    => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IShoppingListService, ShoppingListService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddRateLimiter(opt =>
    {
        opt.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    
        opt.AddPolicy("Default", context => 
            RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: context.Connection.RemoteIpAddress?.ToString(),
                factory: partition => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 15,
                    Window = TimeSpan.FromSeconds(10)
                }));
    
        opt.AddPolicy("Create-New-List", context => 
            RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: context.Connection.RemoteIpAddress?.ToString(),
                factory: partition => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 1,
                    Window = TimeSpan.FromMinutes(5)
                }));
    });
}

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FestivalShoppingContext>();
    context.Database.Migrate();
}

app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.

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