using System.Data;
using FTAP_Portal.Data;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("ftap"));
    conn.Open();
    return conn;
});

builder.Services.AddTransient<ILaptimeRepository, LaptimeRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Laptimes}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();