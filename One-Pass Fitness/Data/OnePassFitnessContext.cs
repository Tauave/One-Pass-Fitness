using One_Pass_Fitness.Models;
using Microsoft.EntityFrameworkCore;

namespace One_Pass_Fitness.Data
{
    public class OnePassFitnessContext : DbContext
    {
        public OnePassFitnessContext(DbContextOptions<OnePassFitnessContext> options) : base(options)
        {
        }

        public DbSet <Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Personalinfo> Personalinfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personalinfo>().ToTable("Personalinfo");
            modelBuilder.Entity<Roles>().ToTable("Roles");

            modelBuilder.Entity<Users>(e =>
            {
                e.ToTable("Users");
                e.HasOne(u => u.Person)
                    .WithMany()
                    .HasForeignKey(u => u.Personid)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(u => u.Role)
                    .WithMany()
                    .HasForeignKey(u => u.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Classes>(e =>
            {
                e.ToTable("Classes");
                e.HasOne(c => c.Role)
                    .WithMany()
                    .HasForeignKey(c => c.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Membership>(e =>
            {
                e.ToTable("Membership");
                e.Property(m => m.MembershipType).HasMaxLength(100);
                e.Property(m => m.Price).HasPrecision(18, 2);
                e.HasOne(m => m.Roles)
                    .WithMany()
                    .HasForeignKey(m => m.Roleid)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
