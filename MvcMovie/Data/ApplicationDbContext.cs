using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<HeThongPhanPhoi> HeThongPhanPhoi { get; set; }
        public DbSet<DaiLy> DaiLy { get; set; }

        // Nếu cần cấu hình chi tiết hơn:
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // ✅ Cấu hình kế thừa TPH giữa Person và Employee
    modelBuilder.Entity<Person>()
        .HasDiscriminator<string>("PersonType")
        .HasValue<Person>("Person")
        .HasValue<Employee>("Employee");

    modelBuilder.Entity<Person>().HasKey(p => p.PersonId);

    modelBuilder.Entity<HeThongPhanPhoi>().HasKey(h => h.MaHTPP);
    modelBuilder.Entity<DaiLy>().HasKey(d => d.MaDaiLy);

    modelBuilder.Entity<DaiLy>()
        .HasOne(d => d.HeThongPhanPhoi)
        .WithMany()
        .HasForeignKey(d => d.MaHTPP)
        .OnDelete(DeleteBehavior.Restrict);
}

    }
}
