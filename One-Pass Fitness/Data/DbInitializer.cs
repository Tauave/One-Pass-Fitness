using One_Pass_Fitness.Models;
using System;
using System.Linq;

namespace One_Pass_Fitness.Data
{
    public class DbInitializer
    {
        public static void Initialize(OnePassFitnessContext context)
        {
            context.Database.EnsureCreated();

            if (context.Roles.Any())
            {
                return;
            }

            var roles = new Roles[]
            {
                new Roles { Role = "Admin" },
                new Roles { Role = "Trainer" },
                new Roles { Role = "Member" }
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();

            var personalInfos = new Personalinfo[]
            {
                new Personalinfo { Name = "John", Lastname = "Doe", DOB = DateOnly.Parse("1990-01-01"), Email = "john.doe@example.com", Phone = "0224651243" },
                new Personalinfo { Name = "Jane", Lastname = "Smith", DOB = DateOnly.Parse("1992-03-15"), Email = "jane.smith@example.com", Phone = "0211111111" },
                new Personalinfo { Name = "Michael", Lastname = "Brown", DOB = DateOnly.Parse("1988-07-22"), Email = "michael.brown@example.com", Phone = "0212222222" },
                new Personalinfo { Name = "Olivia", Lastname = "Wilson", DOB = DateOnly.Parse("1994-11-05"), Email = "olivia.wilson@example.com", Phone = "0213333333" },
                new Personalinfo { Name = "Liam", Lastname = "Taylor", DOB = DateOnly.Parse("1991-02-10"), Email = "liam.taylor@example.com", Phone = "0214444444" }
            };

            context.Personalinfo.AddRange(personalInfos);
            context.SaveChanges();

            var users = new Users[]
            {
                new Users { Personid = personalInfos[0].Personalinfoid, RoleId = roles[0].Roleid, Username = "john.doe", Password = "P@ssword1" },
                new Users { Personid = personalInfos[1].Personalinfoid, RoleId = roles[1].Roleid, Username = "jane.smith", Password = "P@ssword1" },
                new Users { Personid = personalInfos[2].Personalinfoid, RoleId = roles[1].Roleid, Username = "michael.brown", Password = "P@ssword1" },
                new Users { Personid = personalInfos[3].Personalinfoid, RoleId = roles[2].Roleid, Username = "olivia.wilson", Password = "P@ssword1" },
                new Users { Personid = personalInfos[4].Personalinfoid, RoleId = roles[2].Roleid, Username = "liam.taylor", Password = "P@ssword1" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var classes = new Classes[]
            {
                new Classes { Classname = "Yoga", Date = DateOnly.Parse("2026-05-01"), Starttime = TimeOnly.Parse("09:00"), Endtime = TimeOnly.Parse("10:00"), Userid = users[1].Usersid, Availability = "Open" },
                new Classes { Classname = "HIIT", Date = DateOnly.Parse("2026-05-02"), Starttime = TimeOnly.Parse("18:00"), Endtime = TimeOnly.Parse("19:00"), Userid = users[2].Usersid, Availability = "Open" },
                new Classes { Classname = "Pilates", Date = DateOnly.Parse("2026-05-03"), Starttime = TimeOnly.Parse("11:00"), Endtime = TimeOnly.Parse("12:00"), Userid = users[1].Usersid, Availability = "Full" }
            };

            context.Classes.AddRange(classes);
            context.SaveChanges();

            var memberships = new Membership[]
            {
                new Membership { Userid = users[3].Usersid, Startdate = DateOnly.Parse("2026-05-01"), Enddate = DateOnly.Parse("2026-06-01"), Price = 49.99m },
                new Membership { Userid = users[4].Usersid, Startdate = DateOnly.Parse("2026-05-01"), Enddate = DateOnly.Parse("2027-05-01"), Price = 499.99m }
            };

            context.Membership.AddRange(memberships);
            context.SaveChanges();
        }
    }
}