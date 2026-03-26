using One_Pass_Fitness.Models;
using System;
using System.Linq;


namespace One_Pass_Fitness.Data
{
    public class DbInitializer
    {
        public static void Initialize(One_Pass_FitnessContext context)
        {
            context.Database.EnsureCreated();
            // Look for any members.
            if (context.Member.Any())
            {
                return;   // DB has been seeded
            }
            var personalinfos = new Personalinfo[]
            {

            new Personalinfo{Name="John",Lastname="Doe",DOB=DateOnly.Parse("1990-01-01"),Email="johnd@gmail.com" }
            };
        }   
    }
}
