using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

//Scoped：注入的物件在同一Request中，參考的都是相同物件(你在Controller、View中注入的IDbConnection指向相同參考)
builder.Services.AddScoped<IDbConnection, SqlConnection>(serviceProvider => {
    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = configuration.GetConnectionString("ConnectionStrings:DB");
    return conn;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");

app.Run();
