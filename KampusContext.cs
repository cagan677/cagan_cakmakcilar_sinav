using Microsoft.EntityFrameworkCore;
using AdSoyad_Sinav.Models;

namespace AdSoyad_Sinav {
    public class KampusContext : DbContext {
        public KampusContext(DbContextOptions<KampusContext> options) : base(options) { }
        public DbSet<Etkinlik> Etkinlikler { get; set; }
    }
}
