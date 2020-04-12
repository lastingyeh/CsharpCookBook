using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch3
{
    [Flags]
    enum LanguageFlags
    {
        CSharp = 0x0001, VBNET = 0x0002, VB6 = 0x0004, Cpp = 0x0008
    }

    public static class EX311
    {
        public static void Run()
        {
            LanguageFlags lang = LanguageFlags.CSharp | LanguageFlags.VBNET;

            // contains
            if ((lang & LanguageFlags.CSharp) == LanguageFlags.CSharp)
            {
                Console.WriteLine($"it contaions {LanguageFlags.CSharp}");
            }
            else
            {
                Console.WriteLine($"it does not contaions {LanguageFlags.CSharp}");
            }

            // exclusive
            if (lang == LanguageFlags.CSharp)
            {
                Console.WriteLine($"it == {LanguageFlags.CSharp}");
            }
            else
            {
                Console.WriteLine($"it != {LanguageFlags.CSharp}");
            }

            // contains exclusively
            if ((lang != 0) && (lang | (LanguageFlags.CSharp | LanguageFlags.VBNET)) == (LanguageFlags.CSharp | LanguageFlags.VBNET))
            {
                Console.WriteLine($"it only contains {LanguageFlags.CSharp}");
            }
            else
            {
                Console.WriteLine($"it does not only contains {LanguageFlags.CSharp}");
            }

        }
    }
}
