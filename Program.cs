using Microsoft.EntityFrameworkCore;
using cagan_cakmakcilar_sinav;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<KampusContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SomeeBaglantisi")));

var app = builder.Build();

// =========================================================================
// KONTROL KODU: Terminaldeki "database update failed" hatasını bypass eder.
// Proje ayağa kalkarken Somee veritabanındaki tabloları otomatik kontrol eder.
using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<KampusContext>();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        // Bir hata oluşursa projeyi kilitlemesin diye loglayıp geçiyoruz
        Console.WriteLine("Veritabanı kontrol hatası: " + ex.Message);
    }
}
// =========================================================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// GÖREV 4: Controller üzerindeki [Route] etiketlerini aktif eder
app.MapControllers(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();