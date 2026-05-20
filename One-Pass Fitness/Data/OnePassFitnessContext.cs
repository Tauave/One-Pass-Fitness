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
            modelBuilder.Entity<Personalinfo>().ToTable("Personalinfo");
            modelBuilder.Entity<Roles>().ToTable("Roles");

<<<<<<< HEAD
=======
            modelBuilder.Entity<Users>(e =>
            {
                e.ToTable("Users");
                e.HasOne(u => u.Person)
                    .WithMany()
                    .HasForeignKey(u => u.Personid)
                    .OnDelete(DeleteBehavior.Restrict);
            });

>>>>>>> 1f00c30cdd6d1715891b7c8482f56cc2a5f631e5
            modelBuilder.Entity<Classes>(e =>
            {
                e.ToTable("Classes");
                e.ToTable(  
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
