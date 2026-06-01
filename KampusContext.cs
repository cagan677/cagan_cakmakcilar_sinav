using Microsoft.EntityFrameworkCore;
using cagan_cakmakcilar_sinav.Models;

namespace cagan_cakmakcilar_sinav {
    public class KampusContext : DbContext {
        public KampusContext(DbContextOptions<KampusContext> options) : base(options) { }
        public DbSet<Etkinlik> Etkinlikler { get; set; }
    }
}