using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch5
{
    public static class EX513
    {
        public static void Run()
        {
            Citizen mrsJones = new Citizen()
            {
                Honorific = "Mrs.",
                First = "Alice",
                Middle = "G.",
                Last = "Jones"
            };

            Citizen mrJones = new Citizen()
            {
                Honorific = "Mr.",
                First = "Robert",
                Middle = "Frederick",
                Last = "Jones"
            };
        }
    }
}
