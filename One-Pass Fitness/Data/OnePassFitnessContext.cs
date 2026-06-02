using One_Pass_Fitness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace One_Pass_Fitness.Data
{
    public class OnePassFitnessContext : IdentityDbContext
    {
        public OnePassFitnessContext(DbContextOptions<OnePassFitnessContext> options) : base(options)
        {
        }

       
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Personalinfo> Personalinfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Personalinfo>().ToTable("Personalinfo");
            modelBuilder.Entity<Classes>().ToTable("Classes");
            {
                modelBuilder.Entity<Classes>()
                    .HasOne(c => c.Personalinfo)
                    .WithMany()
                    .HasForeignKey(c => c.ClassesId)
                    .OnDelete(DeleteBehavior.Restrict);
            }

            modelBuilder.Entity<Membership>().ToTable("Membership");
            {
                modelBuilder.Entity<Membership>()
                    .HasOne(m => m.Personalinfo)
                    .WithMany()
                    .HasForeignKey(m => m.Personalinfoid)
                    .OnDelete(DeleteBehavior.Restrict);
            }






        }
    }
}
