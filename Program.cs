using gpsapka.Database;
using gpsapka.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


//pøidání služeb
builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddMvc();
builder.Services.AddScoped<VirtuaPlaceSevice>();

var app = builder.Build();

//automatické vytvoøení databáze pokud neexistuje
var scope = app.Services.CreateScope();
scope.ServiceProvider.GetService<AppDBContext>().Database.EnsureCreated();
scope.ServiceProvider.GetService<VirtuaPlaceSevice>().CreateVitrual(); //virtualní hodnoty
scope.Dispose();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//registrace cest do controllerù a jejich akcí
app.MapControllerRoute(
    name: "ESP",
    pattern: "Rest/{action}",
    defaults: new {controller = "ESP"});

app.MapControllerRoute(
    name: "default",
    pattern: "{action}",
    defaults: new { controller = "Home", action = "Index" });

app.Run();
