using FinanceApp.Data;
using FinanceApp.Data.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FinanceAppContext>(options =>
    options.UseMySql(connectionString ?? throw new InvalidOperationException(), new MySqlServerVersion(new Version(8, 0, 40))));

builder.Services.AddScoped<IExpenseService, ExpenseService>();

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
        pattern: "{controller=Expenses}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();