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
            modelBuilder.Entity<Personalinfo>(e =>
            {
                e.ToTable("Personalinfo");
            });

            modelBuilder.Entity<Roles>(e =>
            {
                e.ToTable("Members");
                e.HasOne(m => m.Role)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(m => m.Personid)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Membership>(e =>
            {
                e.ToTable("Membership");
                e.Property(m => m.MembershipType).HasMaxLength(100);
                e.Property(m => m.Price).HasPrecision(18, 2);
                e.HasOne(m => m.Member)
                    .WithMany(m => m.Memberships)
                    .HasForeignKey(m => m.Memberid)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Trainers>(e =>
            {
                e.ToTable("Trainers");
                e.HasOne(t => t.Person)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(t => t.Personid)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Manager>(e =>
            {
                e.ToTable("Manager");
                e.HasOne(m => m.Person)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(m => m.Personid)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Classes>(e =>
            {
                e.ToTable("Classes");
                e.HasOne(c => c.Trainer)
                    .WithMany(t => t.Classes)
                    .HasForeignKey(c => c.Trainerid)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<BookingClasses>(e =>
            {
                e.ToTable("BookingClasses");
                e.HasOne(b => b.Member)
                    .WithMany()
                    .HasForeignKey(b => b.Memberid)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(b => b.Class)
                    .WithMany(c => c.Bookings)
                    .HasForeignKey(b => b.Classid)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
