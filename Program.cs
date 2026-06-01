using Microsoft.EntityFrameworkCore;
using cagan_cakmakcilar_sinav;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<KampusContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SomeeBaglantisi")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// GÖREV 4 Rotaları için aktiflik satırı
app.MapControllers(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();