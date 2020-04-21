using System;
using Newtonsoft.Json;

namespace CookBook.Ch6
{
    public static class EX609
    {
        public static void Run()
        {
            dynamic initialAthletes = new[]
            {
                new
                {
                    Name = "Tom Brady",
                    Sport = "Football",
                    Position = "Quarterback"
                },
                new
                {
                    Name = "Derek Jeter",
                    Sport = "Baseball",
                    Position = "Shortstop"
                },
                new
                {
                    Name = "Michael Jordan",
                    Sport = "Basketball",
                    Position = "Small Forward"
                },
                new
                {
                    Name = "Lionel Messi",
                    Sport = "Soccer",
                    Position = "Forward"
                }
            };

            string serializedAthletes = JsonConvert.SerializeObject(initialAthletes);

            var athletes = JsonConvert.DeserializeObject<DynamicAthlete[]>(serializedAthletes);

            dynamic da = athletes[0];
            Console.WriteLine($"Position of first athlete: {da.Position}");

            foreach (var athlete in athletes)
            {
                dynamic dynamicAthlete = (dynamic)athlete;
                dynamicAthlete.GetUppercaseName = (Func<string>)(() =>
                {
                    return ((string)dynamicAthlete.Name).ToUpper();
                });

                Console.WriteLine($"Athlete:");
                Console.WriteLine(athlete);
                Console.WriteLine($"Uppercase Name: {dynamicAthlete.GetUppercaseName()}");
                Console.WriteLine();
                Console.WriteLine();
            }

            // Wrap an existing athlete
            StaticAthlete staticAthlete = new StaticAthlete()
            {
                Sport = "Hockey"
            };
            dynamic extendedAthlete = new DynamicBase<StaticAthlete>(staticAthlete);
            extendedAthlete.Name = "Bobby Orr";
            extendedAthlete.Position = "Defenseman";
            extendedAthlete.GetUppercaseName = (Func<string>)(() =>
            {
                return ((string)extendedAthlete.Name).ToUpper();
            });
            Console.WriteLine($"Static Athlete (extended):");
            Console.WriteLine(extendedAthlete);
            Console.WriteLine($"Uppercase Name: {extendedAthlete.GetUppercaseName()}");
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
