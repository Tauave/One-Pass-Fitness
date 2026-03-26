using One_Pass_Fitness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace One_Pass_Fitness.Data
{
    public class One_Pass_Fitness : DbContext
    {
        public One_Pass_Fitness(DbContextOptions<One_Pass_Fitness> options) : base(options)
        {
        }


        public DbSet<Admin> Admin { get; set; }
        public DbSet<BookingClasses> BookingClasses { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet <Member> Members { get; set; }
        public DbSet <MembershipInfo> Memberships { get; set; }
        public DbSet <Trainers> Trainers { get; set; }
        public DbSet <Personalinfo> Personalinfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<BookingClasses>().ToTable("BookingClasses");
            modelBuilder.Entity<Classes>().ToTable("Classes");
            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<MembershipInfo>().ToTable("Memberships");
            modelBuilder.Entity<Trainers>().ToTable("Trainers");
            modelBuilder.Entity<Personalinfo>().ToTable("Personalinfo");

        }

    }
}
