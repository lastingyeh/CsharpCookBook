using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1
{
    public static class EX114
    {
        public static void TestPartialMethods()
        {
            Console.WriteLine("Start entity work");

            GeneratedEntity entity = new GeneratedEntity("FirstEntity");
            entity.FirstName = "Bob";
            entity.State = "NH";

            GeneratedEntity secondEntity = new GeneratedEntity("SecondEntity");
            entity.FirstName = "Jay";
            secondEntity.FirstName = "Steve";
            secondEntity.State = "MA";

            entity.FirstName = "Barry";
            secondEntity.State = "WA";
            secondEntity.FirstName = "Matt";

            Console.WriteLine("End entity work");
        }
    }
}
