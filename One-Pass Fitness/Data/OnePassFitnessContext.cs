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
            //    modelBuilder.Entity<Roles>(e =>
            //    {
            //        e.ToTable("Roles");
            //        e.HasKey(r => r.Roleid);
            //        e.HasMany(r => r.Users)
            //            .WithOne(u => u.Role)
            //            .HasForeignKey(u => u.RoleId)
            //            .OnDelete(DeleteBehavior.Restrict);

            //    });


            //    modelBuilder.Entity<Users>(e =>
            //    {
            //        e.ToTable("Users");
            //        e.HasOne(u => u.Person)
            //            .WithMany()
            //            .HasForeignKey(u => u.Personid)
            //            .OnDelete(DeleteBehavior.Restrict);
            //        e.HasOne(u => u.Role)
            //            .WithMany()
            //            .HasForeignKey(u => u.RoleId)
            //            .OnDelete(DeleteBehavior.Restrict);
            //    });

            modelBuilder.Entity<Classes>(e =>
            {
                e.ToTable("Classes");
                e.HasOne(c => c.User)
                    .WithMany(u => u.Classes)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Membership>(e =>
            {
                e.ToTable("Membership");
                e.Property(m => m.Price).HasPrecision(18, 2);
                e.HasOne(m => m.User)
                    .WithMany(u => u.Memberships)
                    .HasForeignKey(m => m.Userid)
                    .OnDelete(DeleteBehavior.Restrict);
            });


        }
    }
}
