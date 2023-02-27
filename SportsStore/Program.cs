using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<StoreDbContext>(
    options =>
    {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("SportsStoreConnection")
        );
    });

builder.Services.AddScoped<IStoreRepository, EFStroreRepository>();


var app = builder.Build();


app.UseStaticFiles();
app.MapDefaultControllerRoute();


SeedData.EnsurePopulated(app);

app.Run();



// docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

