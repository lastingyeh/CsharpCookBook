using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CookBook.Ch3
{
    public enum Language
    {
        Other = 0, CSharp = 1, VBNET = 2, VB6 = 3, ALL = (Other | CSharp | VBNET | VB6)
    }
    public static class EX309
    {
        public static bool CheckLanguageEnumValue(Language language)
        {
            switch (language)
            {
                case Language.CSharp:
                case Language.Other:
                case Language.VB6:
                case Language.VBNET:
                    break;
                default:
                    Debug.Assert(false, $"{language} is not a valid enumeration value to pass.");
                    return false;
            }
            return true;
        }

        public static void HandleEnum(Language language)
        {
            if (CheckLanguageEnumValue(language))
            {
                Console.WriteLine($"{language} is an OK enum value");
            }
            else
            {
                Console.WriteLine($"{language} is not an OK enum value");
            }
        }

        public static void Run()
        {

            HandleEnum(Language.CSharp);
            HandleEnum((Language)1);
            HandleEnum((Language)100);
            int val = 42;
            HandleEnum((Language)val);
        }
    }
}
