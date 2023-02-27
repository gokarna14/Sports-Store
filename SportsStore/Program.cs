var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();



var app = builder.Build();


app.UseStaticFiles();
app.MapDefaultControllerRoute();

// app.MapGet("/", () => "Hello World!");
app.Run();



// docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
