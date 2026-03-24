using One_Pass_Fitness.Models;
using Microsoft.EntityFrameworkCore;

namespace One_Pass_Fitness.Data
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options) : base(options)
        { 
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<BookingClasses> BookingClasses { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet <Member> Members { get; set; }
        public DbSet <MembershipInfo> Memberships { get; set; }
        public DbSet <Trainers> Trainers { get; set; }
        public DbSet <Personalinfo> Personalinfo { get; set; }

    }
}
