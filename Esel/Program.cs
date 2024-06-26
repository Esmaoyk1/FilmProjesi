using Esel.Data;
using Esel.Interface;
using Esel.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EselDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("EselWebContext") ??    //2
    throw new InvalidOperationException("veri taban? bulunamad?")));
//EselDbContext ad?ndaki bir veritaban? ba?lam?n? yap?land?r?r ve bu ba?lam?n
  //  SQL Server veritaban?na ba?lanmas?n? sa?lar.

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepository, EfRepository>();   ///1


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
