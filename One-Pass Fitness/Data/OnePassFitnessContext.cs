using One_Pass_Fitness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace One_Pass_Fitness.Data
{
    public class OnePassFitnessContext : IdentityDbContext<Users>
    {
        public OnePassFitnessContext(DbContextOptions<OnePassFitnessContext> options) : base(options)
        {
        }

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Personalinfo> Personalinfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Classes>().ToTable("Classes");

            modelBuilder.Entity<Membership>().ToTable("Membership");

            modelBuilder.Entity<Membership>()
                .HasOne(m => m.Personalinfo)
                .WithMany()
                .HasForeignKey(m => m.Personalinfoid)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Users>()
                .HasAlternateKey(u => u.Userid);

            modelBuilder.Entity<Membership>()
                .HasOne(m => m.User)
                .WithOne(u => u.Membership)
                .HasForeignKey<Membership>(m => m.Userid)
                .HasPrincipalKey<Users>(u => u.Userid)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
