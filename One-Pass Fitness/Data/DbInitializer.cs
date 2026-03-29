using One_Pass_Fitness.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace One_Pass_Fitness.Data
{
    public class DbInitializer
    {
        public static void Initialize(OnePassFitnessContext context)
        {
            // Ensure migrations are applied rather than using EnsureCreated(), which bypasses migrations.
            context.Database.Migrate();
            // Look for any members.
            if (context.Members.Any())
            {
                return;   // DB has been seeded
            }
            var personalinfos = new Personalinfo[]
            {

            new Personalinfo{Name="John",Lastname="Doe",DOB=DateOnly.Parse("1990-01-01"),Email="johnd@gmail.com", Phone = "0224651243" }
            };
            foreach (Personalinfo p in personalinfos)
            {
                context.Personalinfo.Add(p);
            }
            context.SaveChanges();

            var members = new Member[]
            {
                new Member{Memberid=1,Personid=1,Datejoined=DateOnly.Parse("2023-01-01"),Status="Active"}
            };

            foreach (Member m in members)
            {
                context.Members.Add(m);
            }
            context.SaveChanges();

            var trainers = new Trainers[]
            {
                new Trainers{Trainersid=1,Personid=1,Trainedfield="Strength Training", Datehired=DateOnly.Parse("2023-01-01")}
            };

            foreach (Trainers t in trainers)
            {
                context.Trainers.Add(t);
            }
            context.SaveChanges();

            var classes = new Classes[]
            {
                new Classes{ClassesId = 1,Classname = "Yoga",Date = DateOnly.Parse("2023-01-01"),Starttime = TimeOnly.Parse("10:00"),Endtime = TimeOnly.Parse("11:00"),Trainerid = 1,Availability = "Open"}
            };

            foreach (Classes c in classes)
            {
                context.Classes.Add(c);
            }
            context.SaveChanges();

            var bookings = new BookingClasses[]
            {
                new BookingClasses{BookingClassesId = 1,Memberid = 1,Classid = 1,Bookingdate = DateOnly.Parse("2023-01-01"),Attendancestatus = "Confirmed"}
            };

            foreach (BookingClasses b in bookings)
            {
                context.BookingClasses.Add(b);
            }
            context.SaveChanges();

            var admin = new Admin[]
            {
                new Admin{Adminid = 1,Personid = 1}
            };

            foreach (Admin a in admin)
            {
                context.Admin.Add(a);
            }
            context.SaveChanges();

            var membershipinfo = new MembershipInfo[]
            {
                new MembershipInfo{MembershipInfoid = 1,Memberid = 1,Startdate = DateOnly.Parse("2023-01-01"),Enddate = DateOnly.Parse("2024-01-01")}
            };

            foreach (MembershipInfo mi in membershipinfo)
            {
                context.Memberships.Add(mi);
            }
            context.SaveChanges();
        }   

    }
}
