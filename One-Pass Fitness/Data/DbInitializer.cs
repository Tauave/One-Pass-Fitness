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
            context.Database.EnsureCreated();

            if (context.Members.Any())
            {
                return;
            }

            var personalinfos = new Personalinfo[]
            {
                new Personalinfo { Name = "John", Lastname = "Doe", DOB = DateOnly.Parse("1990-01-01"), Email = "johnd@gmail.com", Phone = "0224651243" },
                new Personalinfo { Name = "Jane", Lastname = "Smith", DOB = DateOnly.Parse("1992-03-15"), Email = "janesmith@gmail.com", Phone = "0211111111" },
                new Personalinfo { Name = "Michael", Lastname = "Brown", DOB = DateOnly.Parse("1988-07-22"), Email = "michaelbrown@gmail.com", Phone = "0212222222" },
                new Personalinfo { Name = "Sarah", Lastname = "Wilson", DOB = DateOnly.Parse("1995-11-10"), Email = "sarahwilson@gmail.com", Phone = "0213333333" },
                new Personalinfo { Name = "David", Lastname = "Taylor", DOB = DateOnly.Parse("1991-05-28"), Email = "davidtaylor@gmail.com", Phone = "0214444444" },
                new Personalinfo { Name = "Emma", Lastname = "Johnson", DOB = DateOnly.Parse("1993-06-12"), Email = "emmajohnson@gmail.com", Phone = "0215555551" },
                new Personalinfo { Name = "Liam", Lastname = "Anderson", DOB = DateOnly.Parse("1989-09-03"), Email = "liamanderson@gmail.com", Phone = "0215555552" },
                new Personalinfo { Name = "Olivia", Lastname = "Thomas", DOB = DateOnly.Parse("1994-12-19"), Email = "oliviathomas@gmail.com", Phone = "0215555553" },
                new Personalinfo { Name = "Noah", Lastname = "Jackson", DOB = DateOnly.Parse("1990-08-08"), Email = "noahjackson@gmail.com", Phone = "0215555554" },
                new Personalinfo { Name = "Ava", Lastname = "White", DOB = DateOnly.Parse("1996-01-25"), Email = "avawhite@gmail.com", Phone = "0215555555" },
                new Personalinfo { Name = "William", Lastname = "Harris", DOB = DateOnly.Parse("1987-04-14"), Email = "williamharris@gmail.com", Phone = "0215555556" },
                new Personalinfo { Name = "Sophia", Lastname = "Martin", DOB = DateOnly.Parse("1993-07-30"), Email = "sophiamartin@gmail.com", Phone = "0215555557" },
                new Personalinfo { Name = "James", Lastname = "Thompson", DOB = DateOnly.Parse("1991-10-11"), Email = "jamesthompson@gmail.com", Phone = "0215555558" },
                new Personalinfo { Name = "Isabella", Lastname = "Garcia", DOB = DateOnly.Parse("1995-02-02"), Email = "isabellagarcia@gmail.com", Phone = "0215555559" },
                new Personalinfo { Name = "Benjamin", Lastname = "Martinez", DOB = DateOnly.Parse("1988-11-18"), Email = "benjaminmartinez@gmail.com", Phone = "0215555560" },
                new Personalinfo { Name = "Mia", Lastname = "Robinson", DOB = DateOnly.Parse("1997-03-21"), Email = "miarobinson@gmail.com", Phone = "0215555561" },
                new Personalinfo { Name = "Lucas", Lastname = "Clark", DOB = DateOnly.Parse("1992-05-16"), Email = "lucasclark@gmail.com", Phone = "0215555562" },
                new Personalinfo { Name = "Charlotte", Lastname = "Rodriguez", DOB = DateOnly.Parse("1994-09-09"), Email = "charlotterodriguez@gmail.com", Phone = "0215555563" },
                new Personalinfo { Name = "Henry", Lastname = "Lewis", DOB = DateOnly.Parse("1989-12-27"), Email = "henrylewis@gmail.com", Phone = "0215555564" },
                new Personalinfo { Name = "Amelia", Lastname = "Lee", DOB = DateOnly.Parse("1996-06-05"), Email = "amelialee@gmail.com", Phone = "0215555565" },
                new Personalinfo { Name = "Alexander", Lastname = "Walker", DOB = DateOnly.Parse("1990-03-13"), Email = "alexanderwalker@gmail.com", Phone = "0215555566" },
                new Personalinfo { Name = "Harper", Lastname = "Hall", DOB = DateOnly.Parse("1998-07-07"), Email = "harperhall@gmail.com", Phone = "0215555567" },
                new Personalinfo { Name = "Daniel", Lastname = "Allen", DOB = DateOnly.Parse("1987-01-17"), Email = "danielallen@gmail.com", Phone = "0215555568" },
                new Personalinfo { Name = "Evelyn", Lastname = "Young", DOB = DateOnly.Parse("1995-04-24"), Email = "evelynyoung@gmail.com", Phone = "0215555569" },
                new Personalinfo { Name = "Matthew", Lastname = "King", DOB = DateOnly.Parse("1991-08-29"), Email = "matthewking@gmail.com", Phone = "0215555570" }
            };

            foreach (Personalinfo p in personalinfos)
            {
                context.Personalinfo.Add(p);
            }
            context.SaveChanges();

            

            var classes = new Classes[]
            {
                new Classes { Classname = "Yoga", Date = DateOnly.Parse("2023-01-01"), Starttime = TimeOnly.Parse("10:00"), Endtime = TimeOnly.Parse("11:00"), Trainerid = trainers[0].Trainersid, Availability = "Open" },
                new Classes { Classname = "Pilates", Date = DateOnly.Parse("2023-01-02"), Starttime = TimeOnly.Parse("11:00"), Endtime = TimeOnly.Parse("12:00"), Trainerid = trainers[1].Trainersid, Availability = "Open" },
                new Classes { Classname = "CrossFit", Date = DateOnly.Parse("2023-01-03"), Starttime = TimeOnly.Parse("12:00"), Endtime = TimeOnly.Parse("13:00"), Trainerid = trainers[2].Trainersid, Availability = "Open" },
                new Classes { Classname = "Cardio Blast", Date = DateOnly.Parse("2023-01-04"), Starttime = TimeOnly.Parse("13:00"), Endtime = TimeOnly.Parse("14:00"), Trainerid = trainers[3].Trainersid, Availability = "Open" },
                new Classes { Classname = "Strength 101", Date = DateOnly.Parse("2023-01-05"), Starttime = TimeOnly.Parse("14:00"), Endtime = TimeOnly.Parse("15:00"), Trainerid = trainers[4].Trainersid, Availability = "Open" }
            };

            foreach (Classes c in classes)
            {
                context.Classes.Add(c);
            }
            context.SaveChanges();

          

            var membershipRows = new Membership[]
            {
                new Membership { Membershipid = member[0].Memberid, MembershipType = "Monthly", Startdate = DateOnly.Parse("2023-01-01"), Enddate = DateOnly.Parse("2023-02-01"), Price = 49.99m },
                new Membership { Memberid = members[1].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2023-02-01"), Enddate = DateOnly.Parse("2024-02-01"), Price = 600m },
                new Membership { Memberid = members[2].Memberid, MembershipType = "Monthly", Startdate = DateOnly.Parse("2023-03-01"), Enddate = DateOnly.Parse("2024-03-01"), Price = 49.99m },
                new Membership { Memberid = members[3].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2023-04-01"), Enddate = DateOnly.Parse("2024-04-01"), Price = 49.99m },
                new Membership { Memberid = members[4].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2023-05-01"), Enddate = DateOnly.Parse("2024-05-01"), Price = 49.99m },
                new Membership { Memberid = members[5].Memberid, MembershipType = "Monthly", Startdate = DateOnly.Parse("2023-06-01"), Enddate = DateOnly.Parse("2024-06-01"), Price = 49.99m },
                new Membership { Memberid = members[6].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2023-07-01"), Enddate = DateOnly.Parse("2024-07-01"), Price = 49.99m },
                new Membership { Memberid = members[7].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2023-08-01"), Enddate = DateOnly.Parse("2024-08-01"), Price = 49.99m },
                new Membership { Memberid = members[8].Memberid, MembershipType = "Monthly", Startdate = DateOnly.Parse("2023-09-01"), Enddate = DateOnly.Parse("2024-09-01"), Price = 49.99m },
                new Membership { Memberid = members[9].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2023-10-01"), Enddate = DateOnly.Parse("2024-10-01"), Price = 49.99m },
                new Membership { Memberid = members[10].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2023-11-01"), Enddate = DateOnly.Parse("2024-11-01"), Price = 49.99m },
                new Membership { Memberid = members[11].Memberid, MembershipType = "Monthly", Startdate = DateOnly.Parse("2023-12-01"), Enddate = DateOnly.Parse("2024-12-01"), Price = 49.99m },
                new Membership { Memberid = members[12].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2024-01-01"), Enddate = DateOnly.Parse("2025-01-01"), Price = 49.99m },
                new Membership { Memberid = members[13].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2024-02-01"), Enddate = DateOnly.Parse("2025-02-01"), Price = 49.99m },
                new Membership { Memberid = members[14].Memberid, MembershipType = "Monthly", Startdate = DateOnly.Parse("2024-03-01"), Enddate = DateOnly.Parse("2025-03-01"), Price = 49.99m },
                new Membership { Memberid = members[15].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2024-04-01"), Enddate = DateOnly.Parse("2025-04-01"), Price = 49.99m },
                new Membership { Memberid = members[16].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2024-05-01"), Enddate = DateOnly.Parse("2025-05-01"), Price = 49.99m },
                new Membership { Memberid = members[17].Memberid, MembershipType = "Monthly", Startdate = DateOnly.Parse("2024-06-01"), Enddate = DateOnly.Parse("2025-06-01"), Price = 49.99m },
                new Membership { Memberid = members[18].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2024-07-01"), Enddate = DateOnly.Parse("2025-07-01"), Price = 49.99m },
                new Membership { Memberid = members[19].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2024-08-01"), Enddate = DateOnly.Parse("2025-08-01"), Price = 49.99m },
                new Membership { Memberid = members[20].Memberid, MembershipType = "Monthly", Startdate = DateOnly.Parse("2024-09-01"), Enddate = DateOnly.Parse("2025-09-01"), Price = 49.99m },
                new Membership { Memberid = members[21].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2024-10-01"), Enddate = DateOnly.Parse("2025-10-01"), Price = 49.99m },
                new Membership { Memberid = members[22].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2024-11-01"), Enddate = DateOnly.Parse("2025-11-01"), Price = 49.99m },
                new Membership { Memberid = members[23].Memberid, MembershipType = "Monthly", Startdate = DateOnly.Parse("2024-12-01"), Enddate = DateOnly.Parse("2025-12-01"), Price = 49.99m },
                new Membership { Memberid = members[24].Memberid, MembershipType = "Annual", Startdate = DateOnly.Parse("2025-01-01"), Enddate = DateOnly.Parse("2026-01-01"), Price = 49.99m }
            };

            foreach (Membership mi in membershipRows)
            {
                context.Memberships.Add(mi);
            }

            context.SaveChanges();

            // Example: renewals / history — second row for first member
            context.Memberships.Add(new Membership
            {
                Memberid = members[0].Memberid,
                MembershipType = "Monthly",
                Startdate = DateOnly.Parse("2024-01-01"),
                Enddate = DateOnly.Parse("2024-02-01"),
                Price = 19.99m
            });
            context.SaveChanges();
        }
    }
}