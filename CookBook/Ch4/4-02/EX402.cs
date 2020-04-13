using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Ch4
{
    public static class EX402
    {
        public static void Run()
        {
            string[] dailySecurityLog =
            {
                "Rakshit logged in",
                "Aaron logged in",
                "Rakshit logged out",
                "Ken logged in",
                "Rakshit logged in",
                "Mahesh logged in",
                "Jesse logged in",
                "Jason logged in",
                "Josh logged in",
                "Melissa logged in",
                "Rakshit logged out",
                "Mary-Ellen logged out",
                "Mahesh logged in",
                "Alex logged in",
                "Scott logged in",
                "Aaron logged out",
                "Jesse logged out",
                "Scott logged out",
                "Dave logged in",
                "Ken logged out",
                "Alex logged out",
                "Rakshit logged in",
                "Dave logged out",
                "Josh logged out",
                "Jason logged out"
            };

            IEnumerable<string> whoLoggedIn =
                dailySecurityLog.Where(logEntry => logEntry.Contains("logged in")).Distinct();

            Console.WriteLine("Everyone who logged in today:");

            foreach (string who in whoLoggedIn)
            {
                Console.WriteLine(who);
            }

            Console.WriteLine("-----Employee-----");

            Employee[] project1 =
            {
                new Employee(){ Name = "Rakshit" },
                new Employee(){ Name = "Jason" },
                new Employee(){ Name = "Josh" },
                new Employee(){ Name = "Melissa" },
                new Employee(){ Name = "Aaron" },
                new Employee(){ Name = "Dave" },
                new Employee(){ Name = "Alex" }
            };

            Employee[] project2 =
            {
                new Employee(){ Name = "Mahesh" },
                new Employee(){ Name = "Ken" },
                new Employee(){ Name = "Jesse" },
                new Employee(){ Name = "Melissa" },
                new Employee(){ Name = "Aaron" },
                new Employee(){ Name = "Alex" },
                new Employee(){ Name = "Mary-Ellen" }
            };

            Employee[] project3 =
            {
                new Employee(){ Name = "Mike" },
                new Employee(){ Name = "Scott" },
                new Employee(){ Name = "Melissa" },
                new Employee(){ Name = "Aaron" },
                new Employee(){ Name = "Alex" },
                new Employee(){ Name = "Jon" }
            };

            Console.WriteLine("\r\nUnion (Employees for all projects)");
            var allProjectEmployees = project1.Union(project2.Union(project3));
            foreach (Employee employee in allProjectEmployees)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine("\r\nIntersect (Employees on every project)");
            var everyProjectEmployees = project1.Intersect(project2.Intersect(project3));
            foreach (Employee employee in everyProjectEmployees)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine("\r\nExcept (Employees on only one project)");
            var intersect1_3 = project1.Intersect(project3);
            var intersect1_2 = project1.Intersect(project2);
            var intersect2_3 = project2.Intersect(project3);
            var unionIntersect = intersect1_2.Union(intersect1_3).Union(intersect2_3);

            var onlyProjectEmployees = allProjectEmployees.Except(unionIntersect);
            foreach (Employee employee in onlyProjectEmployees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
