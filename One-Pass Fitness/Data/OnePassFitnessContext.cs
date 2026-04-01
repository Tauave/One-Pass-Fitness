using One_Pass_Fitness.Models;
using Microsoft.EntityFrameworkCore;

namespace One_Pass_Fitness.Data
{
    public class OnePassFitnessContext : DbContext
    {
        public OnePassFitnessContext(DbContextOptions<OnePassFitnessContext> options) : base(options)
        {
        }


        public DbSet<Manager> Manager { get; set; }
        public DbSet<BookingClasses> BookingClasses { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MembershipInfo> Memberships { get; set; }
        public DbSet<Trainers> Trainers { get; set; }
        public DbSet<Personalinfo> Personalinfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().ToTable("Manager");
            modelBuilder.Entity<BookingClasses>().ToTable("BookingClasses");
            modelBuilder.Entity<Classes>().ToTable("Classes");
            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<MembershipInfo>().ToTable("Memberships");
            modelBuilder.Entity<Trainers>().ToTable("Trainers");
            modelBuilder.Entity<Personalinfo>().ToTable("Personalinfo");

        }

    }
}
