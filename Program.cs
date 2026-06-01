using Microsoft.EntityFrameworkCore;
using AdSoyad_Sinav;

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

// GÖREV 4 İÇİN KRİTİK: Controller üzerindeki [Route] etiketlerini aktif eder
app.MapControllers(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();