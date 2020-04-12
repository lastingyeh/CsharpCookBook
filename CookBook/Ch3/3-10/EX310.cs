using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch3
{
    // ToString || ToString("G") => const string
    // Or operator combine
    [Flags]
    public enum RecycleItems
    {
        None = 0x00,
        Glass = 0x01,
        AluminumCans = 0x02,
        MixedPaper = 0x04,
        Newspaper = 0x08,
        TinCans = 0x10,
        Cardboard = 0x20,
        ClearPlastic = 0x40,
        All = (None | Glass | AluminumCans | MixedPaper | Newspaper | TinCans | Cardboard | ClearPlastic | ClearPlastic)
    }

    [Flags]
    enum LanguageFlag
    {
        CSharp = 0x0001, VBNET = 0x0002, VB6 = 0x0004, Cpp = 0x0008,
        CobolNET = 0x000F, FortranNET = 0x0010, JSharp = 0x0020,
        MSIL = 0x0080,
        All = (CSharp | VBNET | VB6 | Cpp | FortranNET | JSharp | MSIL),
        VBOnly = (VBNET | VB6),
        NonVB = (CSharp | Cpp | FortranNET | JSharp | MSIL)
    }

    public static class EX310
    {
        public static void Run()
        {
            RecycleItems items = RecycleItems.Glass | RecycleItems.Newspaper;
            Console.WriteLine(items);

            //Glass           0001
            //AluminumCans    0010
            //ORed bit values 0011

            if ((items & RecycleItems.Glass) == RecycleItems.Glass)
            {
                Console.WriteLine("The enum contains the C# enumeration value");
            }
            else
            {
                Console.WriteLine("The enum does NOT contain the C# value");
            }
        }
    }
}
